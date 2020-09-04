##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /src
COPY ["discord-bot/discord-bot.csproj", "discord-bot/"]
COPY . .
WORKDIR "/src/discord-bot"
RUN dotnet publish "discord-bot.csproj" -c Release -o /app/publish

RUN apt-get update && apt-get install -y libopus0 libsodium23 ffmpeg
RUN apt-get install -y libogg0 opus-tools libopusfile0 libopus-dev libsodium-dev

WORKDIR /app/publish
ENTRYPOINT ["dotnet", "discord-bot.dll"]