using Discord;
using Discord.Commands;
using Discord.WebSocket;
using discord_bot.Clients;
using discord_bot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace discord_bot
{
    class Program
    {
        private readonly DiscordSocketClient _client;
        private readonly IConfiguration _configuration;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public Program()
        {
            _client = new DiscordSocketClient();
            _configuration = GetConfiguration();
        }

        public async Task MainAsync()
        {
            var services = ConfigureServices();
            services.GetRequiredService<LogService>();
            await services.GetRequiredService<CommandHandlingService>().InitializeAsync(services);

            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("DISCORD_BOT_CLIENT_SECRET"));
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                // Base
                .AddLogging()
                .AddSingleton(_client)
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandlingService>()
                .AddSingleton<LogService>()
                .AddTransient<IGifService, GifService>()
                .AddSingleton(_configuration);

            services.AddRefitClient<IJokeClient>(new RefitSettings())
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(_configuration["clients:joke:url"]));

            services.AddRefitClient<IGifClient>(new RefitSettings())
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(_configuration["clients:gif:url"]));

            return services.BuildServiceProvider();
        }

        private IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
