using discord_bot.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot.Clients
{
    /// <summary>
    /// https://api.tenor.com/v1/search
    /// </summary>
    public interface IGifClient
    {
        [Get("/search?q={request.q}&contentFilter={request.contentFilter}&key={key}")]
        Task<GifResponse> GetGif(string key, GifRequest request);
    }
}
