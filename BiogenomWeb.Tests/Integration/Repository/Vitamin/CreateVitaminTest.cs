namespace BiogenomWeb.Tests.Integration.Repository.Vitamin;

public class CreateVitaminTest : IClassFixture<BaseTestContainersIntegration>
{
    private readonly BaseTestContainersIntegration _integration;

    public CreateVitaminTest(BaseTestContainersIntegration integration)
    {
        _integration = integration;
    }

    [Fact]
    public async Task CreateVitaminAsyncTest()
    {
        await _integration.VitaminRepository!.CreateVitaminAsync("Test");
    }
}