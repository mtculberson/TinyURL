using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL.Controllers;
using TinyURL.Models;

namespace TinyURL
{
    class ConsoleInterface
    {
        TinyURLController urlService;

        public ConsoleInterface()
        {
            this.urlService = new TinyURLController();
        }

        public void ShowOptions()
        {
            Console.WriteLine(" \r\nBelow are our provided services:");
            Console.WriteLine("Generate new TinyURL [A]");
            Console.WriteLine("Retrieve an existing long URL from a TinyURL [B]");
            Console.WriteLine("Get number of times a TinyURL was visited [C]");
            Console.WriteLine("Delete an existing TinyURL [D]");
            Console.WriteLine("Display existing TinyURLs [E]");

            string userResponse = Console.ReadLine();

            if (userResponse == "A")
            {
                GenerateTinyURL();
            }
            else if (userResponse == "B")
            {
                RetrieveLongURL();
            }
            else if (userResponse == "C")
            {
                GetTimesVisited();
            }
            else if (userResponse == "D")
            {
                DeleteTinyURL();
            }
            else if (userResponse == "E")
            {
                DisplayTinyURLs();
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid input. Please try again.");
                ShowOptions();
                return;
            }
        }

        private void GenerateTinyURL()
        {
            Console.WriteLine("Please provide a long URL:");

            string longURL = Console.ReadLine();

            if (longURL == "" || longURL == null || string.IsNullOrWhiteSpace(longURL))
            {
                Console.WriteLine("Input provided is not valid. Please try again.");
                GenerateTinyURL();
                return;
            }

            Console.WriteLine("If you would like to provide a custom TinyURL, please enter now. Otherwise leave blank:");

            string shortURL = Console.ReadLine();

            string tinyURL = "";

            if (shortURL == "" || shortURL == null || string.IsNullOrWhiteSpace(shortURL))
            {
                tinyURL = urlService.CreateShortURL(longURL, null);
            }
            else
            {
                tinyURL = urlService.CreateShortURL(longURL, shortURL);
            }

            Console.WriteLine("Your TinyURL for the website " + longURL + " is: " + tinyURL);
            ShowOptions();
        }

        private void RetrieveLongURL()
        {
            Console.WriteLine("Please provide a TinyURL:");

            string tinyURL = Console.ReadLine();

            if (tinyURL == "" || tinyURL == null || string.IsNullOrWhiteSpace(tinyURL) || !tinyURL.Contains("/"))
            {
                Console.WriteLine("Input provided is not valid. Please try again.");
                RetrieveLongURL();
                return;
            }

            string longURL = this.urlService.GetLongURL(tinyURL);
            Console.WriteLine("The long URL for your TinyURL, " + tinyURL + ", is: " + longURL);
            ShowOptions();
        }

        private void GetTimesVisited()
        {
            Console.WriteLine("Please provide a TinyURL:");

            string tinyURL = Console.ReadLine();

            if (tinyURL == "" || tinyURL == null || string.IsNullOrWhiteSpace(tinyURL) || !tinyURL.Contains("/"))
            {
                Console.WriteLine("Input provided is not valid. Please try again.");
                GetTimesVisited();
                return;
            }

            int timesClicked = this.urlService.GetNumberOfTimesClicked(tinyURL);
            Console.WriteLine("Your TinyURL, " + tinyURL + ", has been visited " + timesClicked + " times.");
            ShowOptions();
        }

        private void DeleteTinyURL()
        {
            Console.WriteLine("Please provide a TinyURL:");

            string tinyURL = Console.ReadLine();

            if (tinyURL == "" || tinyURL == null || string.IsNullOrWhiteSpace(tinyURL) || !tinyURL.Contains("/"))
            {
                Console.WriteLine("Input provided is not valid. Please try again.");
                GetTimesVisited();
                return;
            }

            this.urlService.DeleteShortURL(tinyURL);
            Console.WriteLine("Your TinyURL, " + tinyURL + ", has been deleted.");
            ShowOptions();
        }

        private void DisplayTinyURLs()
        {
            Dictionary<string, URL> tinyURLs = this.urlService.GetTinyURLS();

            foreach (var url in tinyURLs.Values)
            {
                Console.WriteLine("Long URL: " + url.LongURL + ", TinyURL: " + url.ShortURL);
            }

            ShowOptions();
        }
    }
}
