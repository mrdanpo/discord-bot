using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

public class AudioModule : ModuleBase<ICommandContext>
{
    private readonly IAudioService _service;

    public AudioModule(IAudioService service)
    {
        _service = service;
    }

    [Command("rain", RunMode = RunMode.Async)]
    public async Task JoinCmd()
    {
        var song = $"{Directory.GetCurrentDirectory()}\\assets\\rain.mp4";
        await _service.JoinAudio(Context.Guild, (Context.User as IVoiceState).VoiceChannel);
        await _service.SendAudioAsync(Context.Guild, Context.Channel, song);
    }

    [Command("leave", RunMode = RunMode.Async)]
    public async Task LeaveCmd()
    {
        await _service.LeaveAudio(Context.Guild);
    }
}