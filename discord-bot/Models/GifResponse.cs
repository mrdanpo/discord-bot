using System;
using System.Collections.Generic;
using System.Text;

namespace discord_bot.Models
{
    public class GifResponse
    {
        public List<GifResponseItem> Results { get; set; }
    }

    public class GifResponseItem
    {
        public string Url { get; set; }
    }
}
