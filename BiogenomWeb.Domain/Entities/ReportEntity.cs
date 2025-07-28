namespace BiogenomWeb.Domain.Entities;

/// <summary>
/// Таблица отчетов диагностики пользователя.
/// </summary>
public class ReportEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата создания отчета диагностики пользователя.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
