using DataSearchContain.Application.Commands.Search;
using DataSearchContain.Domain.UnitOfWork;
using DataSearchContain.Infrastructure.UnitOfWork;
using DataSearchContain.UnitTest.DataGenrators.SearchAmountDataGenerator;
using Moq;
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
			Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
			var token = new CancellationToken();
			var handler =
				new SearchAmountCommandHandler(
					mock.Object
					).Handle(null, token);

			await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
				handler);
		}

		[Theory]
		[ClassData(typeof(TestSearchAmountDataGeneratorInvalidValues))]
		public async Task ThrowArgumentNullException_RequestsRequestIsInvalid(string request)
		{
			Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
			var command = new SearchAmountCommand(request);
			var token = new CancellationToken();
			var handler =
				new SearchAmountCommandHandler(
					mock.Object
					).Handle(command, token);

			await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
				handler);
		}

		[Theory]
		[ClassData(typeof(TestSearchAmountDataGeneratorValidAmount))]
		public async Task SearchContainAmountHandler_ContainsRequest_true(string request)
		{
			Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
			int _amounts = 23;
			mock.Setup(x => x.Repository.MatchingItems(request)).Returns(Task.FromResult(_amounts));

			var command = new SearchAmountCommand(request);
			var token = new CancellationToken();
			var handler =
				await new SearchAmountCommandHandler(
					mock.Object
					).Handle(command, token);

			 Assert.Equal(_amounts, handler);
		}



	}
}