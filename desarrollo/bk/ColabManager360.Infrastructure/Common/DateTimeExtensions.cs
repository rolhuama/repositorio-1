namespace ColabManager360.Infrastructure.Common
{
    internal static class DateTimeExtensions
    {
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return date.AddMonths(1).AddDays(-date.Day);
        }
    }
}
