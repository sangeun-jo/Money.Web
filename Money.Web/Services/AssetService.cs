
using Money.Shared.DTOs.Asset;
using Money.Shared.Enums;
using Money.Shared.Interfaces;

namespace Money.Web.Services;

public class AssetService : IAssetService
{

    private readonly IHttpService _httpService;

    public AssetService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<IEnumerable<AssetDisplayDto>?> GetAllAssetAsync(AssetType? type)
    {
        return await _httpService.GetAsync<IEnumerable<AssetDisplayDto>>($"/api/asset?type={(int?)type}");
    }
    
    public async Task<AssetDisplayDto?> GetAssetByIdAsync(long assetId)
    {
        return await _httpService.GetAsync<AssetDisplayDto>($"/api/asset/{assetId}");
    }

    public async Task CreateAssetAsync(AssetCreateDto asset)
    {
        await _httpService.PostAsync("/api/asset", asset);
    }

    public async Task UpdateAssetAsync(AssetUpdateDto asset)
    {
        await _httpService.PutAsync("/api/asset", asset);
    }

    public async Task DeleteAssetAsync(long assetId)
    {
        await _httpService.DeleteAsync($"/api/asset/{assetId}");
    }
}