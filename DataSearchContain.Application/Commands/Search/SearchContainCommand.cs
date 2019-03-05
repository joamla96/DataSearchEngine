using DataSearchContain.Domain.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public SearchContainCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> Handle(SearchContainCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Request))
                throw new ArgumentNullException(nameof(request.Request));

            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));

            return 
                await _unitOfWork.Repository.WordExist(request.Request);
        }
    }
}
