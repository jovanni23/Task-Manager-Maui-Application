using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManager.Maui.Services
{
    public class QuoteService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string> GetRandomQuotes()
        {
            try
            {
                var json = await _httpClient.GetStringAsync("https://zenquotes.io/api/quotes/random");
                var quotes = JsonSerializer.Deserialize<List<Quote>>(json);
                var firstQuote = quotes.FirstOrDefault();

                if (firstQuote == null)
                {
                    return "No quote available for today.";
                }
                return $"{firstQuote.q} - {firstQuote.a}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return $"Stay Motivated!";
            }
            
        }
    }

    public class Quote
    {
        public string q { get; set; }

        public string a { get; set; }
    }
}
