using System;
using System.Collections.Generic;
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
    }
}
