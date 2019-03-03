using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSearchContain.Application.Commands.Search
{
    public class SearchContainCommand
        : IRequest<bool>
    {
        public SearchContainCommand(string request)
        {
            this.Request = request;
        }

        public string Request { get; }
    }

    public class SearchContainCommandHandler
        : IRequestHandler<SearchContainCommand, bool>
    {
        public async Task<bool> Handle(SearchContainCommand request, CancellationToken cancellationToken)
        {

            return true;
        }
    }
}
