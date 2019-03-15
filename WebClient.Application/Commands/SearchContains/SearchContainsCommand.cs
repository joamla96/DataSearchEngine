using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebClient.Domain.Gateway;

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
        private readonly IGateway _Gateway;

        public SearchContainCommandHandler(IGateway gateway)
        {
            _Gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
        }

        public async Task<List<string>> Handle(SearchContainCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Request))
                throw new ArgumentNullException(nameof(request.Request));

            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));

			try {

				var result = await _Gateway.WordExist(request.Request);
				return new List<string>() { request.Request, result.ToString() };

			} catch(Exception e) {
				return new List<string>() { request.Request, e.Message };
			}
        }
    }
}
