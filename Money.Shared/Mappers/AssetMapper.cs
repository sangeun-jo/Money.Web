
using Money.Shared.DTOs.Asset;

namespace Money.Shared.Mappers;

public static class AssetMapper
{
    public static AssetUpdateDto ToAssetUpdateDto(this AssetDisplayDto asset)
    {
        return new AssetUpdateDto
        {
            Id = asset.Id,
            AssetType = asset.AssetType,
            Name = asset.Name,
            Amount = asset.Amount
        };
    }
}