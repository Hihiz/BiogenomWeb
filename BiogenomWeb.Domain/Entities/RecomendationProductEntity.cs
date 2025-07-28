namespace BiogenomWeb.Domain.Entities;

/// <summary>
/// Таблица рекомендаций (персонализированных наборов) БАДов для пользователя.
/// </summary>
public class RecomendationProductEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название набора (БАДа).
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Путь до картинки набора (БАДа).
    /// </summary>
    public string? ImageUrl { get; set; }
}
