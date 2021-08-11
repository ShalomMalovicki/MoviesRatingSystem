using MoviesRatingSystem.Data;
using MoviesRatingSystem.Resources;
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
            var lastReceived = DateTime.Now.AddSeconds(-1);
            var lastReceived2 = DateTime.Now;
         
            //var r1 = api.GetMoviesDescrption().Result;
            var r2 = api.GetOnlineVotes(lastReceived).Result;
            //var r3 = ConvertFunc.ConvertFromDateTime(lastReceived);

            Console.WriteLine($"\n\n{r2}");
        }

    }
}
