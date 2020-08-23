using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using discord_bot.Clients;
using discord_bot.Models;
using discord_bot.Services;

namespace discord_bot.Modules
{
    public class ApiMoudle : ModuleBase<SocketCommandContext>
    {
        private readonly IJokeClient _jokeClient;
        private readonly IGifService _gifService;

        public ApiMoudle(IJokeClient jokeClient, IGifService gifService)
        {
            _jokeClient = jokeClient;
            _gifService = gifService;
        }

        [Command("joke")]
        public async Task Joke()
        {
            try
            {
                var joke = await _jokeClient.GetJoke();

                if (string.IsNullOrEmpty(joke?.Joke))
                {
                    await ReplyAsync("I can't think of a joke right now.");
                }

                await ReplyAsync(joke.Joke);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Command("gif")]
        public async Task Gif([Remainder]string q)
        {
            try
            {                

                var request = new GifRequest()
                {
                    Q = q,
                    ContentFilter = ContentFilter.Off
                };

                var result = await _gifService.GetGif(request);

                if (string.IsNullOrEmpty(result?.Url))
                {
                    await ReplyAsync("I can't find a gif right now");
                }

                await ReplyAsync(result.Url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}