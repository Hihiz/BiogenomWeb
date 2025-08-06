using BiogenomWeb.Domain.Entities;
using Moq;

namespace BiogenomWeb.Tests.Unit.Service.Vitamin
{
    public class GetVitaminByVitaminIdTest : BaseUnitTest
    {
        [Fact]
        public async Task GetVitaminByVitaminIdAsyncTest()
        {
            // Arrange
            int vitaminId = 1;

            MockVitaminRepository
                .Setup(repo => repo.GetVitaminByVitaminIdAsync(vitaminId))
                .ReturnsAsync(BaseVitaminEntities.First());

            // Act
            var result = await VitaminService.GetVitaminByVitaminIdAsync(vitaminId);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetVitaminByVitaminIdAsyncIdZeroTest()
        {
            // Arrange
            int vitaminId = 0;

            // Act
            Exception exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await VitaminService.GetVitaminByVitaminIdAsync(vitaminId);
            });

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task GetVitaminByVitaminIdAsyncNotFoundTest()
        {
            // Arrange
            int vitaminId = 999;

            VitaminEntity? entity = null;

            MockVitaminRepository
                .Setup(repo => repo.GetVitaminByVitaminIdAsync(vitaminId))!
                .ReturnsAsync(entity);

            // Act
            var result = await VitaminService.GetVitaminByVitaminIdAsync(vitaminId);

            // Assert
            Assert.NotNull(result);
        }
    }
}
