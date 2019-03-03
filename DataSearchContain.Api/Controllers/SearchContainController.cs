using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSearchContain.Application.Commands.Search;
using DataSearchContain.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataSearchContain.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchContainController : Controller
    {
        private readonly IMediator _mediator;

        public SearchContainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Exist()
        {
            bool result = await _mediator.Send<bool>(new SearchContainCommand("cake"));

            return new OkObjectResult(result);
        }
        
    }
}