namespace BiogenomWeb.Domain.Entities;

/// <summary>
/// Таблица витаминов/минералов.
/// </summary>
public class VitaminEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название витамина/минерала.
    /// </summary>
    public string Title { get; set; } = null!;
}
