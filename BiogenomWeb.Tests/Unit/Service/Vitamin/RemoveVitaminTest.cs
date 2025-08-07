namespace BiogenomWeb.Tests.Unit.Service.Vitamin
{
    public class RemoveVitaminTest : BaseUnitTest
    {
        [Fact]
        public async Task RemoveVitaminAsyncTest()
        {
            // Arrange
            var vitaminId = 1;

            // Act & Assert
            await VitaminService.RemoveVitaminAsync(vitaminId);
        }

        [Fact]
        public async Task RemoveVitaminAsyncTestIdZero()
        {
            // Arrange
            int vitaminId = 0;

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await VitaminService.RemoveVitaminAsync(vitaminId);
            });
        }
    }
}
