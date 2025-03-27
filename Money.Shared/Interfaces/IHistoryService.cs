using Money.Shared.DTOs.History;

namespace Money.Shared.Interfaces;

public interface IHistoryService
{
    Task CreateHistoryAsync(HistoryCreateDto history);

    Task UpdateHistoryAsync(HistoryUpdateDto history);

    Task DeleteHistoryAsync(long historyId);

    // date 형식 yyyy-MM
    Task<IEnumerable<HistoryDisplayDto>?> GetAllHistoryAsync(string? date);

    Task<HistoryDisplayDto?> GetHistoryByIdAsync(long historyId);
}