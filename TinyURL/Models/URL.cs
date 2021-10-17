using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Models
{
    class URL
    {
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public int NumberOfTimesVisited { get; set; }

        public URL(string longUrl, string shortURL, int numberOfTimesVisited = 0)
        {
            this.LongURL = longUrl;
            this.ShortURL = shortURL;
            this.NumberOfTimesVisited = numberOfTimesVisited;
        }
    }
}
