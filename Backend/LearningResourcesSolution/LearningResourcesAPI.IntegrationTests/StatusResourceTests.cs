using LearningResourcesAPI.Controllers;

namespace LearningResourcesAPI.IntegrationTests
{
    public class StatusResourceTests
    {
        [Fact]
        public async Task TheStatusResource()
        {
            await using var host = await AlbaHost.For<Program>();

            var response = await host.Scenario(api => //integration test - usually has many steps
            {
                api.Get.Url("/status");
                api.StatusCodeShouldBeOk(); //200 status code
            });

            var responseMessage = response.ReadAsJson<GetStatusResponse>();

            Assert.NotNull(responseMessage);
            Assert.Equal("All's Good", responseMessage.Message);
            Assert.Equal("555-555-5555", responseMessage.Contact);
        }
    }
}
