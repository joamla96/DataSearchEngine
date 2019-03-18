using DataSearchContain.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSearchContain.Application.Commands.Search
{
	public class SearchAmountCommand : IRequest<int>
	{
		public SearchAmountCommand(string request)
		{
			this.Request = request;
		}

		public string Request { get; }
	}
	public class SearchAmountCommandHandler
	  : IRequestHandler<SearchAmountCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;

		public SearchAmountCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

	
		public async Task<int> Handle(SearchAmountCommand request, CancellationToken cancellationToken)
		{

			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (String.IsNullOrWhiteSpace(request.Request))
				throw new ArgumentNullException(nameof(request.Request));

			if (cancellationToken == null)
				throw new ArgumentNullException(nameof(cancellationToken));

			return
				await _unitOfWork.Repository.MatchingItems(request.Request);

		}


	}
}

