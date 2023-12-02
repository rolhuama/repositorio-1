namespace ColabManager360.Infrastructure.Common
{
    internal static class Utilities
    {
        public static int CalculateDaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            TimeSpan duration = endDate - startDate;
            int numberOfDays = (int)Math.Abs(duration.TotalDays) + 1;
            return numberOfDays;
        }

        public static int CalculateBusinessDaysInMonth(int Year, int Month)
        {
            // Define el mes y el año para el que deseas contar los días hábiles
            int year = Year; // Cambia esto al año que necesites
            int month = Month;   // Cambia esto al mes que necesites

            // Obtén el primer día del mes
            DateTime firstDayOfMonth = new DateTime(year, month, 1);

            // Obtiene el último día del mes
            DateTime lastDayOfMonth = firstDayOfMonth.LastDayOfMonth();

            int businessDays = 0;

            // Itera a través de los días del mes
            for (DateTime date = firstDayOfMonth; date <= lastDayOfMonth; date = date.AddDays(1))
            {
                // Verifica si el día actual es un día laborable (de lunes a viernes)
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    businessDays++;
                }
            }


            return businessDays;
        }



    }
}
