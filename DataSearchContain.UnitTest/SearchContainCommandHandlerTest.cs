using DataSearchContain.Application.Commands.Search;
using DataSearchContain.UnitTest.DataGenrators.SearchContainDataGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DataSearchContain.UnitTest
{
    public class SearchContainCommandHandlerTest
    {

        [Fact]
        public async Task ThrowArgumentNullException_RequestIsNull()
        {
            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler().Handle(null, token);

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
                new SearchContainCommandHandler().Handle(command, token);

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
                new SearchContainCommandHandler().Handle(null, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }



    }
}
