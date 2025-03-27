using System.ComponentModel.DataAnnotations;
using Money.Shared.Enums;

namespace Money.Shared.DTOs.Asset;

public class AssetDisplayDto
{
    [Required] public long Id { get; set; }
    [Required] public AssetType AssetType { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public int? Amount { get; set; }

}