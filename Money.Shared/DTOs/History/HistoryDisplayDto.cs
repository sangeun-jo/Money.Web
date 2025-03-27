using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.History;

public class HistoryDisplayDto
{
    [Required] public long Id { get; set; }
    [Required] public MoneyType MoneyType { get; set; }
    [Required] public int? CategoryId { get; set; }
    [Required] public int? Amount { get; set; }
    
    public string? Place { get; set; }
    public string? Note { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }

}