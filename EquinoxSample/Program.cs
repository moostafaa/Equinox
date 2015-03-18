using System;
using System.Globalization;
using Equinox;

namespace EquinoxSample
{
    class Program
    {
        public static string ToShamsiDateTime(DateTime gregorianDateTime)
        {
            var year = gregorianDateTime.Year;
            var month = gregorianDateTime.Month;
            var day = gregorianDateTime.Day;
            var persianCalendar = new PersianCalendar();
            var yearShamsi = persianCalendar.GetYear(new DateTime(year, month, day, new GregorianCalendar()));
            var monthShamsi = persianCalendar.GetMonth(new DateTime(year, month, day, new GregorianCalendar()));
            var dayShamsi = persianCalendar.GetDayOfMonth(new DateTime(year, month, day, new GregorianCalendar()));
            return string.Format("{0}{1}{2}{1}{3} {4}:{5}:{6}",
                yearShamsi,
                "/",
                monthShamsi.ToString("00", CultureInfo.InvariantCulture),
                dayShamsi.ToString("00", CultureInfo.InvariantCulture),
                gregorianDateTime.Hour.ToString("00"),
                gregorianDateTime.Minute.ToString("00"),
                gregorianDateTime.Second.ToString("00"));
        }


        static void Main(string[] args)
        {
            //this sample will compute persian new year start time
            var gregorianDateTime = 2015.GetSunEventUtc(SunEvent.VernalEquinox).AddHours(3.5);
            var persianDateTime = ToShamsiDateTime(gregorianDateTime);
            Console.WriteLine("{0} -> {1}", 2015, persianDateTime);
        }
    }
}
