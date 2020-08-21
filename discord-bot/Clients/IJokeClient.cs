using discord_bot.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot.Clients
{
    /// <summary>
    /// https://sv443.net/jokeapi/v2/?ref=apilist.fun#getting-started
    /// </summary>
    public interface IJokeClient
    {
        [Get("/Any")]
        Task<JokeDto> GetJoke();
    }
}
