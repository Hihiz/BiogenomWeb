namespace BiogenomWeb.Domain.Entities;

/// <summary>
/// Таблица с результатами диагностики пользователя.
/// </summary>
public class VitaminReportEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// FK Id отчета диагностики пользователя.
    /// </summary>
    public int ReportId { get; set; }

    /// <summary>
    /// Навигационное свойство отчета диагностики.
    /// </summary>
    public ReportEntity? Report { get; set; }

    /// <summary>
    /// FK Id витамина/минерала.
    /// </summary>
    public int VitaminId { get; set; }

    /// <summary>
    /// Навигационное свойство витаминов/минералов..
    /// </summary>
    public VitaminEntity? Vitamin { get; set; }

    /// <summary>
    /// Текущее значение витамина/минерала.
    /// </summary>
    public decimal CurrentValue { get; set; }

    /// <summary>
    /// Значение витамина/минерала которое является нормой.
    /// </summary>
    public decimal ReferenceValue { get; set; }

    /// <summary>
    /// Значение витамина/минерала которое можно получить из питания. 
    /// </summary>
    public decimal FoodValue { get; set; }

    /// <summary>
    /// Значение витамина/минерала которое можно получить из набора (БАДов).
    /// </summary>
    public decimal SupplementValue { get; set; }

    /// <summary>
    /// Снижено ли значение витамина/минерала.
    /// </summary>
    public bool IsDeficit { get; set; }   
}
