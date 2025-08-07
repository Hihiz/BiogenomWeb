namespace BiogenomWeb.Tests.Integration.Repository.Vitamin;

public class UpdateVitaminTest : IClassFixture<BaseTestContainersIntegration>
{
    private readonly BaseTestContainersIntegration _integration;

    public UpdateVitaminTest(BaseTestContainersIntegration integration)
    {
        _integration = integration;
    }

    [Fact]
    public async Task UpdateVitaminAsyncTest()
    {
        // Arrange
        var vitaminId = (await _integration.VitaminRepository!.GetVitaminsAsync()).FirstOrDefault()!.Id;

        // Act
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            await _integration.VitaminRepository!.UpdateVitaminAsync(vitaminId, "Update Vitamin");
        });

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public async Task UpdateVitaminAsyncIdZeroTest()
    {
        // Arrange & Act
        Exception exception = await Record.ExceptionAsync(async () =>
        {
            await _integration.VitaminRepository!.UpdateVitaminAsync(0, "Update Vitamin");
        });

        // Assert
        Assert.NotNull(exception);
    }
}