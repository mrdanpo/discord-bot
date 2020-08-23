using discord_bot.Clients;
using discord_bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot.Services
{
    public interface IGifService
    {
        Task<GifResponseItem> GetGif(GifRequest request);
    }

    public class GifService : IGifService
    {
        private readonly IGifClient _gifClient;

        public GifService(IGifClient gifClient)
        {
            _gifClient = gifClient;
        }

        public async Task<GifResponseItem> GetGif(GifRequest request)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("TENOR_API_KEY");

                var result = await _gifClient.GetGif(apiKey, request);

                var random = new Random();

                if (result?.Results == null || result.Results.Count() == 0)
                {
                    return null;
                }

                return result.Results.ElementAt(random.Next(0, result.Results.Count()));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
