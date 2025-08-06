namespace BiogenomWeb.Tests.Unit.Service.Vitamin
{
    public class UpdateVitaminTest : BaseUnitTest
    {
        [Fact]
        public async Task UpdateVitaminAsyncTest()
        {
            // Arrange
            int vitaminId = 1;
            string title = "Update Vitamin";

            // Act & Assert
            await VitaminService.UpdateVitaminAsync(vitaminId, title);
        }

        [Fact]
        public async Task UpdateVitaminAsyncIdZeroTest()
        {
            // Arrange
            int vitaminId = 0;
            string title = "Update Vitamin";

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async delegate
            {
                await VitaminService.UpdateVitaminAsync(vitaminId, title);
            });
        }

        [Fact]
        public async Task UpdateVitaminAsyncTitleEmptyTest()
        {
            // Arrange
            int vitaminId = 1;
            string title = string.Empty;

            // Act
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async delegate
            {
                await VitaminService.UpdateVitaminAsync(vitaminId, title);
            });

            // Assert
            Assert.NotEmpty(ex.Message);
        }
    }
}
