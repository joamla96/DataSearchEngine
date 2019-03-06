using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebClient.Domain.UnitOfWork;

namespace WebClient.Application.Commands.SearchAmount
{
	public class SearchAmountCommand
		: IRequest<List<string>>
	{
		public SearchAmountCommand(string request)
		{
			this.Request = request;
		}

		public string Request { get; }
	}

	public class SearchAmountCommandHandler
		: IRequestHandler<SearchAmountCommand, List<string>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public SearchAmountCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<List<string>> Handle(SearchAmountCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			if (request.Request == null)
				throw new ArgumentNullException(nameof(request.Request));

			if (request.Request == "")
				throw new ArgumentNullException(nameof(request.Request));

			if (cancellationToken == null)
				throw new ArgumentNullException(nameof(cancellationToken));

			var result = await _unitOfWork.Repository.WordExist(request.Request);
			return new List<string>() { request.Request, result.ToString() };
		}
	}
}
