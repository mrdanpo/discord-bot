# discord-bot

## Running with Docker

The bot can be ran with the dockerfile:
```
cd discord-bot
docker build --tag discord-bot:1.0 .
docker run -e DISCORD_BOT_CLIENT_SECRET=<token> --detach --name discord-bot discord-bot:1.0
```

Or docker-compose. This way will need an env file called environment-variables.env setting up with the variable `DISCORD_BOT_CLIENT_SECRET`:
```
cd discord-bot
docker-compose up -d
```