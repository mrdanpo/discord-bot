using System;
using System.Threading.Tasks;
using Discord.Commands;
using discord_bot.Clients;

namespace discord_bot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public Task Info()
            => ReplyAsync(
                $"Hello, I am a bot called {Context.Client.CurrentUser.Username} written in Discord.Net 1.0\n");
    }
}