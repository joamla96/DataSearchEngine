using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebClient.Application.Commands.SearchContains;
using WebClient.Infrastructure.UnitOfWorks;
using WebClient.UnitTest.DataGenrators.SearchContainDataGenerator;
using Xunit;

namespace WebClient.UnitTest
{
    public class SearchContainCommandHandlerTest
    {

        [Fact]
        public async Task ThrowArgumentNullException_RequestIsNull()
        {
            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler(
                    new UnitOfWork()
                    ).Handle(null, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }

        [Theory]
        [ClassData(typeof(TestSearchContainDataGeneratorInvalidValues))]
        public async Task ThrowArgumentNullException_RequestsRequestIsInvalid(string request)
        {
            var command = new SearchContainCommand(request);
            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler(
                    new UnitOfWork()
                    ).Handle(command, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }

        [Theory]
        [ClassData(typeof(TestSearchContainDataGeneratorValidSearch))]
        public async Task SearchContainCommandHandler_ContainsRequest_true(string request)
        {
            var command = new SearchContainCommand(request);
            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler(
                    new UnitOfWork()
                    ).Handle(null, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }



    }
}
