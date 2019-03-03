using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.IO;

namespace ProcessFileService.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class MainController : ControllerBase {
		// POST api/values
		[HttpPost]
		public bool Post([FromBody] SearchForModel model) {

			var keywordfound = false;
			foreach (var line in System.IO.File.ReadAllLines(model.path)) {
				foreach (var a in model.input) {
					if (line.Contains(a))
						keywordfound = true;
				}
			}

			if (!keywordfound) return false;

			return true;
		}
	}

	public class SearchForModel {
		public string path { get; set; }
		public string[] input { get; set; }
	}

}
