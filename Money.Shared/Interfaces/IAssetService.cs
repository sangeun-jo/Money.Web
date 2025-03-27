using Money.Shared.DTOs.Asset;
using Money.Shared.Enums;

namespace Money.Shared.Interfaces;

public interface IAssetService
{
    // 자산 전체 조회
    Task<IEnumerable<AssetDisplayDto>?> GetAllAssetAsync(AssetType? type);
    
    // 자산 1개 조회
    Task<AssetDisplayDto?> GetAssetByIdAsync(long assetId);
    
    // 자산 추가
    Task CreateAssetAsync(AssetCreateDto asset);
    
    // 자산 수정
    Task UpdateAssetAsync(AssetUpdateDto asset);
    
    // 자산 삭제
    Task DeleteAssetAsync(long assetId);
}