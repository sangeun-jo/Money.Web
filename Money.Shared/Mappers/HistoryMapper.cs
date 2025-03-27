using Money.Shared.DTOs.History;
using Money.Shared.Enums;
namespace Money.Shared.Mappers;

public static class HistoryMapper
{
    public static HistoryUpdateDto ToHistoryUpdateDto(this HistoryDisplayDto history)
    {
        return new HistoryUpdateDto
        {
            Id =  history.Id,
            MoneyType = history.MoneyType,
            CategoryId = history.CategoryId,
            Amount = history.Amount,
            Place = history.Place,
            Note = history.Note,
            CreatedDate = history.CreatedDate
        };
    }
}