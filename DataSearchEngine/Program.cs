using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DataSearchEngine {
	class Program {
		private static int Counter = 0;

		private static Stopwatch timer;

		private static readonly object _lock = new object();
		static void Main(string[] args) {
			Program p = new Program();

			while (true) {
				Counter = 0;
				timer = new Stopwatch();

				Console.WriteLine("Hello!");

				Console.WriteLine("Please input search string:");
				var input = Console.ReadLine();

				Console.WriteLine("Please hold while searching...");
				var inputs = input.Split(' ');

				timer.Start();
				p.ProcessDirectory("data/", inputs);
				timer.Stop();

				Console.WriteLine("Done, Results: " + Counter.ToString());
				Console.WriteLine("Took {0} ms, {1} s", timer.ElapsedMilliseconds, timer.Elapsed);
				Console.WriteLine("\nEnter to reset.");
				Console.ReadLine();
				Console.Clear();
			}
		}

		public void ProcessDirectory(string targetDirectory, string[] inputs) {
			// Process the list of files found in the directory.
			string[] fileEntries = Directory.GetFiles(targetDirectory);
			foreach(var fileName in fileEntries) {
				ProcessFile(fileName, inputs);
			}

			// Recurse into subdirectories of this directory.
			string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
			foreach(var subdirectory in subdirectoryEntries) {
				ProcessDirectory(subdirectory, inputs);
			}
		}

		// Insert logic for processing found files here.
		public static void ProcessFile(string path, string[] inputs) {
			var client = new RestClient("http://localhost:29697/api");

			var request = new RestRequest("main");

			var model = new SearchForModel() {
				path = Directory.GetCurrentDirectory() + "/" + path,
				input = inputs
			};

			request.RequestFormat = DataFormat.Json;
			request.AddJsonBody(model);

			var response = client.Execute(request, Method.POST);

			bool found = bool.Parse(response.Content);
			if (!found) return;

			lock(_lock) {
				Counter++;
			}
			Console.WriteLine("Found in " + path);
		}

		public class SearchForModel {
			public string path { get; set; }
			public string[] input { get; set; }
		}
	}
}
