using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebClient.Application.Commands.SearchContains;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        SearchViewModel model = new SearchViewModel();
        public IActionResult Index()
        {
            return View(new List<SearchViewModel>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public async Task<IActionResult> SearchAnQuarry(string search)
        {
			var results = new List<SearchViewModel>();

			var totalTimer = new Stopwatch();
			totalTimer.Start();
			
			for (int i = 0; i < 10; i++) {
				var model = new SearchViewModel();
				model.timer.Start();
				model.SearchResults = await _mediator.Send<List<String>>(new SearchContainCommand(search));
				model.timer.Stop();
				results.Add(model);
			}

			totalTimer.Stop();

			ViewData["TotalTime"] = totalTimer.ElapsedMilliseconds;

            return View("Index",results);
        }
    }
}
