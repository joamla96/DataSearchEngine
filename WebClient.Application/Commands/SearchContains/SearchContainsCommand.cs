using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebClient.Application.Commands.SearchContains
{
    public class SearchContainCommand
        : IRequest<List<string>>
    {
        public SearchContainCommand(string request)
        {
            this.Request = request;
        }

        public string Request { get; }
    }

    public class SearchContainCommandHandler
        : IRequestHandler<SearchContainCommand, List<string>>
    {
        public async Task<List<string>> Handle(SearchContainCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Request == null)
                throw new ArgumentNullException(nameof(request.Request));

            if (request.Request == "")
                throw new ArgumentNullException(nameof(request.Request));

            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));


            return new List<string>() { "cake",request.Request, "coffee"};
        }
    }
}
