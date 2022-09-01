using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KanyeREST
{
    public class QuoteService : IQuoteService
    {
        private HttpClient _client;
        const string swansonUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        const string kanyeUrl = "https://api.kanye.rest";
        public QuoteService(HttpClient client)
        {
            _client = client;
        }
        public string GetKanyeQuote()
        {
            var kResponse = _client.GetStringAsync(kanyeUrl).Result;
            return JObject.Parse(kResponse).GetValue("quote").ToString();

        }

        public string GetRonQuote()
        {
            var rResponse = _client.GetStringAsync(swansonUrl).Result;
            return JArray.Parse(rResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim().Trim('"');
        }
    }
}
