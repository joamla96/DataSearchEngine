using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using WebClient.Application.Commands.SearchAmount;

using WebClient.Infrastructure.UnitOfWorks;
using WebClient.UnitTest.DataGenrators.AmountContainerDataGenerator;
using Xunit;

namespace WebClient.UnitTest
{
	public class SearchAmountCommandHandlerTest
	{
		[Fact]
		public async Task ThrowArgumentNullException_RequestIsNull()
		{
			var token = new CancellationToken();
			var handler =
				new SearchAmountCommandHandler(
					new UnitOfWork()
					).Handle(null, token);

			await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
				handler);
		}

		[Theory]
		[ClassData(typeof(TestSearchAmountDataGeneratorInvalidValues))]
		public async Task ThrowArgumentNullException_RequestsRequestIsInvalid(string request)
		{
			var command = new SearchAmountCommand(request);
			var token = new CancellationToken();
			var handler =
				new SearchAmountCommandHandler(
					new UnitOfWork()
					).Handle(command, token);

			await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
				handler);
		}

		[Theory]
		[ClassData(typeof(TestSearchAmountDataGeneratorValidAmounts))]
		public async Task SearchAmountCommandHandler_ContainsRequest_true(string request)
		{
			var command = new SearchAmountCommand(request);
			var token = new CancellationToken();
			var handler =
				new SearchAmountCommandHandler(
					new UnitOfWork()
					).Handle(null, token);

			await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
				handler);
		}



	}
}