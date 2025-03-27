


using Money.Shared.DTOs.History;
using Money.Shared.Interfaces;

public class HistoryService : IHistoryService
{
    private IHttpService _httpService;

    public HistoryService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task CreateHistoryAsync(HistoryCreateDto history)
    {
        await _httpService.PostAsync("/api/history", history);
    }

    public async Task DeleteHistoryAsync(long historyId)
    {
        await _httpService.DeleteAsync($"/api/history/{historyId}");
    }

    public async Task<IEnumerable<HistoryDisplayDto>?> GetAllHistoryAsync(string? date)
    {
        return await _httpService.GetAsync<IEnumerable<HistoryDisplayDto>?>($"/api/history?date={date}");
    }

    public async Task<HistoryDisplayDto?> GetHistoryByIdAsync(long historyId)
    {
        return await _httpService.GetAsync<HistoryDisplayDto?>($"/api/history/{historyId}");
    }

    public async Task UpdateHistoryAsync(HistoryUpdateDto history)
    {
        await _httpService.PutReturnAsync<HistoryUpdateDto?>("/api/history", history);
    }
}