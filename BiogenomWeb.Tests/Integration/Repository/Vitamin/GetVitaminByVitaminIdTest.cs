using BiogenomWeb.Domain.Entities;

namespace BiogenomWeb.Tests.Integration.Repository.Vitamin;

public class GetVitaminByVitaminIdTest : IClassFixture<BaseTestContainersIntegration>
{
    private readonly BaseTestContainersIntegration _integration;

    public GetVitaminByVitaminIdTest(BaseTestContainersIntegration integration)
    {
        _integration = integration;
    }

    [Fact]
    public async Task GetVitaminByVitaminIdAsyncTest()
    {
        // Arrange & Act
        VitaminEntity result = await _integration.VitaminRepository.GetVitaminByVitaminIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
    }

    [Fact]
    public async Task GetVitaminByVitaminIdAsyncIdZeroTest()
    {
        // Arrange && Act
        VitaminEntity result = await _integration.VitaminRepository!.GetVitaminByVitaminIdAsync(0);

        // Assert
        Assert.Null(result);
    }
}

