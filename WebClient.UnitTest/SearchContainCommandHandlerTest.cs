using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebClient.Application.Commands.SearchContains;
using WebClient.Domain.Gateway;
using WebClient.UnitTest.DataGenrators.SearchContainDataGenerator;
using Xunit;

namespace WebClient.UnitTest
{
    public class SearchContainCommandHandlerTest
    {

        [Fact]
        public async Task ThrowArgumentNullException_RequestIsNull()
        {

            Mock<IGateway> gateway = new Mock<IGateway>();

            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler(
                    gateway.Object
                    ).Handle(null, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }

        [Theory]
        [ClassData(typeof(TestSearchContainDataGeneratorInvalidValues))]
        public async Task ThrowArgumentNullException_RequestsRequestIsInvalid(string request)
        {
            Mock<IGateway> gateway = new Mock<IGateway>();

            var command = new SearchContainCommand(request);
            var token = new CancellationToken();
            var handler =
                new SearchContainCommandHandler(
                    gateway.Object
                    ).Handle(command, token);

            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
                handler);
        }

        [Theory]
        [ClassData(typeof(TestSearchContainDataGeneratorValidSearch))]
        public async Task SearchContainCommandHandler_ContainsRequest_true(string request)
        {
            Mock<IGateway> gateway = new Mock<IGateway>();
            gateway.Setup(x => x.WordExist(request)).Returns(Task.FromResult(false));

            var command = new SearchContainCommand(request);
            var token = new CancellationToken();
            var handler =
                await new SearchContainCommandHandler(
                    gateway.Object
                    ).Handle(command, token);

            Assert.NotEmpty(handler);
        }
    }
}
