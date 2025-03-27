using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace Money.Shared.Extenstions;

/// <summary>
/// 열거형 확장 클래스
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// 열거형의 [Display] 속성에 작성한 문자열을 반환함
    /// </summary>
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
    }
}