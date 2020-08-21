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
                await ReplyAsync(joke.Joke);
            }
            catch (Exception e)
            {
                // TODO
            }
        }
    }
}