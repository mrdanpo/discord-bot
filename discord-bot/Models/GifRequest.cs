using System;
using System.Collections.Generic;
using System.Text;

namespace discord_bot.Models
{
    public class GifRequest
    {
        public string Q { get; set; }
        public string ContentFilter { get; set; }
    }

    public static class ContentFilter 
    {
        public static string Off = "off";
    }
}
