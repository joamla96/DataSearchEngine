using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class SearchViewModel
    {
        public List<string> SearchResults { get; set; }

        public SearchViewModel()
        {
            SearchResults = new List<string>();
        }
    }
}
