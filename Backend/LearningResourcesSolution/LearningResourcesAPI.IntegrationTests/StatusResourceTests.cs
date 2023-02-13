using LearningResourcesAPI.Controllers;
using LearningResourcesAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace LearningResourcesAPI.IntegrationTests
{
    public class StatusResourceTests
    {
        [Fact]
        public async Task TheStatusResource()
        {
            await using var host = await AlbaHost.For<Program>();

            await host.Scenario(api => //integration test - usually has many steps
            {
                api.Get.Url("/status");
                api.StatusCodeShouldBeOk(); //200 status code
            });
        }

        [Fact]
        public async Task TheContactIsAPhoneNumberDuringBusinessHours()
        {
            await using var host = await AlbaHost.For<Program>(builder =>
            {
                var stubbedSystemTime = new Mock<ISystemTime>();
                stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.BeforeCutoffTime);
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
                });
            });

            var response = await host.Scenario(api => //integration test - usually has many steps
            {
                api.Get.Url("/status");
            });


            var responseMessage = response.ReadAsJson<GetStatusResponse>();

            //our we could create a new object of GetStatusReponse (it must be a Record)
            var expectedMessage = new GetStatusResponse("All's Good", "555-555-5555");

            // Make invalid status impossible.

            Assert.NotNull(responseMessage);
            Assert.Equal(expectedMessage, responseMessage);
        }

        [Fact]
        public async Task TheContactIsAnEmailOutsideBusinessHours()
        {
            await using var host = await AlbaHost.For<Program>(builder =>
            {
                var stubbedSystemTime = new Mock<ISystemTime>();
                stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.AfterCutoffTime);
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
                });
            });

            var response = await host.Scenario(api => //integration test - usually has many steps
            {
                api.Get.Url("/status");
            });


            var responseMessage = response.ReadAsJson<GetStatusResponse>();

            Assert.NotNull(responseMessage);
            Assert.Equal("All's Good", responseMessage.Message);
            Assert.Equal("bob@aol.com", responseMessage.Contact);
        }
    }
}
