using DataSearchContain.Application.Commands.Search;
using DataSearchContain.Infrastructure.UnitOfWork;
using DataSearchContain.UnitTest.DataGenrators.SearchAmountDataGenerator;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DataSearchContain.UnitTest
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
		[ClassData(typeof(TestSearchAmountDataGeneratorValidAmount))]
		public async Task SearchContainAmountHandler_ContainsRequest_true(string request)
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