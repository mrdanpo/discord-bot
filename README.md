# discord-bot

## Running with Docker

`docker build --tag discord-bot:1.0 .`
`docker run -e DISCORD_BOT_CLIENT_SECRET=<token> --detach --name discord-bot discord-bot:1.0`