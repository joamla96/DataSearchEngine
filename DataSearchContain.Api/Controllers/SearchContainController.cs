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

        [HttpPost]
        public async Task<IActionResult> Exist([FromBody] SearchQuarryDTO quarry)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();
            if (quarry == null)
                return new BadRequestObjectResult(nameof(quarry));
            if(string.IsNullOrWhiteSpace(quarry.Quarry))
                return new BadRequestObjectResult(nameof(quarry));

            bool result = await _mediator.Send<bool>(new SearchContainCommand(quarry.Quarry));

            return new OkObjectResult(result);
        }
        
    }
}