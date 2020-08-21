using System;
using System.Collections.Generic;
using System.Text;

namespace discord_bot.Models
{
    public class JokeDto
    {
        public string Error { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Joke { get; set; }
        public JokeFlags Flags { get; set; }
        public int Id { get; set; }
        public string Lang { get; set; }
    }

    public class JokeFlags
    {
        public string Nsfw { get; set; }
        public string Religious { get; set; }
        public string Political { get; set; }
        public string Rascist { get; set; }
        public string Sexist { get; set; }
    }
}
