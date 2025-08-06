namespace BiogenomWeb.Tests.Integration.Repository.Vitamin;

public class RemoveVitaminTest : IClassFixture<BaseTestContainersIntegration>
{
    private readonly BaseTestContainersIntegration _integration;

    public RemoveVitaminTest(BaseTestContainersIntegration integration)
    {
        _integration = integration;
    }

    [Fact]
    public async Task RemoveVitaminAsyncTest()
    {
        // Arrange
        await _integration.VitaminRepository.CreateVitaminAsync("Create Vitamin");

        // Act & Assert
        await _integration.VitaminRepository!.RemoveVitaminAsync(1);
    }

    [Fact]
    public async Task RemoveVitaminAsyncIdZeroTest()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(() => 
            _integration.VitaminRepository!.RemoveVitaminAsync(0));
    }
}

