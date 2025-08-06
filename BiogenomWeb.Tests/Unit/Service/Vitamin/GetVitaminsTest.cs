using Moq;

namespace BiogenomWeb.Tests.Unit.Service.Vitamin
{
    public class GetVitaminsTest : BaseUnitTest
    {
        [Fact]
        public async Task GetVitaminsAsyncTest()
        {
            // Arrange
            MockVitaminRepository
               .Setup(repo => repo.GetVitaminsAsync())
               .ReturnsAsync(BaseVitaminEntities);

            // Act
            var result = await VitaminService.GetVitaminsAsync();

            // Assert
            Assert.NotNull(result);
        }
    }
}