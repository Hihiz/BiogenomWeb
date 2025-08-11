namespace BiogenomWeb.Application.Dto.Input.Vitamin
{
    /// <summary>
    /// Класс входной модели редактирования витамина.
    /// </summary>
    public class UpdateVitaminInput
    {
        /// <summary>
        /// Id витамина.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название витамина.
        /// </summary>
        public string? Title { get; set; }
    }
}
