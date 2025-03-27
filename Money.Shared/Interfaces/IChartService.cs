using Money.Shared.DTOs.Chart;
using Money.Shared.Enums;

namespace Money.Shared.Interfaces;

public interface IChartService
{
    // 월간 통계
    Task<IEnumerable<ChartDisplayDto>?> GetMonthChartAsync(string? date, MoneyType? type);
}