using MoviesRatingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem_Test
{
    class Program
    {
        static void Main()
        {
            var api = new MovieRestApi();

            RestTests(api).Wait();
            Console.ReadLine();
        }

        private static async Task RestTests(MovieRestApi api)
        {         
            var dateStart = DateTime.UtcNow.AddHours(-24);
            var dateEnd = DateTime.UtcNow;
         
            var r1 = api.GetMoviesDescrption().Result;
         
            Console.WriteLine($"\n\n{r1}");
        }

    }
}
