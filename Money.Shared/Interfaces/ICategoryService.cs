using Money.Shared.DTOs.Category;
using Money.Shared.Enums;

namespace Money.Shared.Interfaces;

public interface ICategoryService
{
    // 카테고리 목록 조회
    Task<IEnumerable<CategoryDisplayDto>?> GetAllCategoryAsync(MoneyType? type);
    
    // 카테고리 상세 조회
    Task<CategoryDisplayDto?> GetCategoryByIdAsync(long categoryId);

    // 카테고리 추가
    Task CreateCategoryAsync(CategoryCreateDto category);
    
    // 카테고리 수정
    Task UpdateCategoryAsync(CategoryUpdateDto category);

    // 카테고리 삭제
    Task DeleteCategoryAsync(long categoryId);
}