namespace BiogenomWeb.Tests.Unit.Service.Vitamin
{
    public class CreateVitaminTest : BaseUnitTest
    {
        [Fact]
        public async Task CreateVitaminAsyncTest()
        {
            // Arrange
            string title = "New Title";

            // Act & Assert
            await VitaminService.CreateVitaminAsync(title);
        }

        [Fact]
        public async Task CreateVitaminAsyncTitleNullTest()
        {
            // Arrange
            string title = string.Empty;

            // Act
            Exception exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await VitaminService.CreateVitaminAsync(title);
            });

            //  Assert
            Assert.NotEmpty(exception.Message);
        }
    }
}
