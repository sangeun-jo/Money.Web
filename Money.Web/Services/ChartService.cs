using Money.Shared.DTOs.Chart;
using Money.Shared.Enums;
using Money.Shared.Interfaces;

namespace Money.Web.Services;

public class ChartService : IChartService
{
    private readonly IHttpService _httpService;
    
    public ChartService(IHttpService httpService)
    {
        _httpService = httpService;
    }


    public async Task<IEnumerable<ChartDisplayDto>?> GetMonthChartAsync(string? date, MoneyType? type)
    {
        return await _httpService.GetAsync<IEnumerable<ChartDisplayDto>>($"/api/chart?date={date}&type={(int?)type}");
    }
}