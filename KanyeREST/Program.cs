using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KanyeREST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQuoteService quoteService = new QuoteService(new HttpClient());
            Random random = new Random();
            Console.WriteLine("A Profound Conversation Between Kanye West and Ron Swanson.\n\nPrepare to be enlightened.\n\n");
            for (int i = 0; i < 5; i++)
            {
                var kanyeText = quoteService.GetKanyeQuote();
                Console.WriteLine($"Kanye: {kanyeText}\n");
                Task.Delay(random.Next(500, 1500)).Wait();

                var ronText = quoteService.GetRonQuote();
                Console.WriteLine($"Ron: {ronText}\n");
                Task.Delay(random.Next(500, 1500)).Wait();
            }
        }
    }
}
