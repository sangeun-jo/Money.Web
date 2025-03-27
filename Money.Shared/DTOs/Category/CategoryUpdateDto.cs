using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.Category;

public class CategoryUpdateDto
{
    [Required] 
    public long Id { get; set; }
    
    [Required] 
    public MoneyType MoneyType { get; set; }
    
    [Required] 
    public string? Name { get; set; }
    
}