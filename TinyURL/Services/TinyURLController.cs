using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL.Models;

namespace TinyURL.Controllers
{
    class TinyURLController
    {
        private Dictionary<string, URL> URLDictionary { get; set; }

        private const string DOMAIN = "bit.ly";


        public TinyURLController ()
        {
            this.URLDictionary = new Dictionary<string, URL>();
        }

        /* Method to create short URLs with associated long URLs.
           Accepts longURL and an optional parameter, customShortURL.
           Returns the shortURL. */
        public string CreateShortURL(string longURL, string customShortURL = null)
        {
            if (longURL == "" || longURL == null || string.IsNullOrWhiteSpace(longURL))
            {
                throw new ArgumentNullException("Must provide valid URL to generate TinyURL.");
            }

            string shortUrl = "";

            if (customShortURL != null)
            {
                shortUrl = customShortURL;
            }
            else
            {
                shortUrl = GenerateURLHelper.GenerateTinyURL();
            }

            while (URLDictionary.ContainsKey(shortUrl))
            {
                shortUrl = GenerateURLHelper.GenerateTinyURL();
            }

            string tinyUrl = DOMAIN + "/" + shortUrl;

            URL urlObject = new URL(longURL, tinyUrl, 0);
            this.URLDictionary.Add(shortUrl, urlObject);

            return tinyUrl;
        }

        /* Method to delete short URLs with associated long URLs.
           Accepts shortURL as a parameter. */
        public void DeleteShortURL(string shortURL)
        {
            if (shortURL == "" || shortURL == null || string.IsNullOrWhiteSpace(shortURL) || !shortURL.Contains("/"))
            {
                throw new ArgumentNullException("Must provide valid shortURL to delete.");
            }

            shortURL = shortURL.Split('/')[1];

            if (this.URLDictionary.ContainsKey(shortURL))
            {
                this.URLDictionary.Remove(shortURL);
            }
            else
            {
                throw new KeyNotFoundException("TinyURL provided does not exist in our records.");
            }
        }

        /* Method to retrieve longURL and updates each time visited.
           Accepts shortURL and returns the shortURL. */
        public string GetLongURL(string shortURL)
        {
            if (shortURL == "" || shortURL == null || string.IsNullOrWhiteSpace(shortURL) || !shortURL.Contains("/"))
            {
                throw new ArgumentNullException("Must provide valid shortURL.");
            }

            shortURL = shortURL.Split('/')[1];
            URL urlObject;

            if (!this.URLDictionary.TryGetValue(shortURL, out urlObject))
            {
                throw new KeyNotFoundException("TinyURL provided does not exist in our records.");
            }

            urlObject.NumberOfTimesVisited++;
            this.URLDictionary[shortURL] = urlObject;

            return urlObject.LongURL;
        }

        /* Method to retrieve amount of times a shortURL was visited.
           Accepts the shortURL and returns the number of times visited. */
        public int GetNumberOfTimesClicked(string shortURL)
        {
            if (shortURL == "" || shortURL == null || string.IsNullOrWhiteSpace(shortURL) || !shortURL.Contains("/"))
            {
                throw new ArgumentNullException("Must provide valid shortURL.");
            }

            shortURL = shortURL.Split('/')[1];
            URL urlObject;

            if (!this.URLDictionary.TryGetValue(shortURL, out urlObject))
            {
                throw new KeyNotFoundException("TinyURL provided does not exist in our records.");
            }

            return urlObject.NumberOfTimesVisited;
        }

        /* Method to return all URLs saved in Dictionary */
        public Dictionary<string, URL> GetTinyURLS()
        {
            return this.URLDictionary;
        }

    }
}
