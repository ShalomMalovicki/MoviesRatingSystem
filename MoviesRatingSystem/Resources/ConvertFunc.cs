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
        // for set the data in exact api format yyyy-MM-ddTHH:mm:ss
        public static string ConvertFromDateTime(DateTime time)
        {
            return $"{time.Year}-{time.Month}-{time.Day}T{time.ToLongTimeString()}";
        }

        // For use on a specific date of 06/01/2021 09:57:51 as the requirements
        public static DateTime ConvertToFullDateTimeWithSeconds(string dayAndTime)
        {
            var dt = DateTime.ParseExact(dayAndTime, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return DateTime.SpecifyKind(dt, DateTimeKind.Local);
        }
    }
}
