using Money.Shared.DTOs.Category;
using Money.Shared.Enums;
using Money.Shared.Interfaces;

namespace Money.Web.Services;

public class CategoryService : ICategoryService
{
    private IHttpService _httpService;

    public CategoryService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<IEnumerable<CategoryDisplayDto>?> GetAllCategoryAsync(MoneyType? type)
    {
        return await _httpService.GetAsync<IEnumerable<CategoryDisplayDto>>($"/api/category?type={(int?)type}");
    }

    public async Task<CategoryDisplayDto?> GetCategoryByIdAsync(long categoryId)
    {
        return await _httpService.GetAsync<CategoryDisplayDto>($"/api/category/{categoryId}");
    }

    public async Task CreateCategoryAsync(CategoryCreateDto category)
    {
        await _httpService.PostAsync("/api/category", category);
    }

    public async Task UpdateCategoryAsync(CategoryUpdateDto category)
    {
        await _httpService.PutAsync("/api/category", category);
    }
    
    public async Task DeleteCategoryAsync(long categoryid)
    {
        await _httpService.DeleteAsync($"/api/category/{categoryid}");
    }
}