using BiogenomWeb.Domain.Entities;

namespace BiogenomWeb.Tests.Integration.Repository.Vitamin;

public class GetVitaminsTest : IClassFixture<BaseTestContainersIntegration>
{
    private readonly BaseTestContainersIntegration _integration;

    public GetVitaminsTest(BaseTestContainersIntegration integration)
    {
        _integration = integration;
    }

    [Fact]
    public async Task GetVitaminsAsyncTest()
    {
        // Arrange && Act    
        IEnumerable<VitaminEntity> result = await _integration.VitaminRepository!.GetVitaminsAsync();

        // Assert
        Assert.NotNull(result);
    }
}