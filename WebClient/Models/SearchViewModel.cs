using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace WebClient.Models
{
    public class SearchViewModel
    {
        public List<string> SearchResults { get; set; }
		public Stopwatch timer { get; set; }

        public SearchViewModel()
        {
			timer = new Stopwatch();
            SearchResults = new List<string>();
        }
    }
}
