using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Resources
{
    public static class ConvertFunc
    {
        public static string ConvertFromDateTime(DateTime time)
        {
            return $"{time.Year}-{time.Month}-{time.Day}T{time.ToLongTimeString()}";
        }

        public static DateTime ConvertToFullDateTimeWithSeconds(string dayAndTime)
        {
            var dt = DateTime.ParseExact(dayAndTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return DateTime.SpecifyKind(dt, DateTimeKind.Local);
        }
    }
}
