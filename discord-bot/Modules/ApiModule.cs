using System;
using System.Threading.Tasks;
using Discord.Commands;
using discord_bot.Clients;

namespace discord_bot.Modules
{
    public class ApiMoudle : ModuleBase<SocketCommandContext>
    {
        private readonly IJokeClient _jokeClient;   

        public ApiMoudle(IJokeClient jokeClient)
        {
            _jokeClient = jokeClient;
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
    }
}