using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL
{
    public static class GenerateURLHelper
    {
        public static string GenerateTinyURL()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<char> characters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '_' };

            Random random = new Random();
            string URL = "";

            for (int i = 0; i < 3; i++)
            {
                URL += characters[random.Next(0, characters.Count)];
            }

            for (int i = 0; i < 3; i++)
            {
                URL += numbers[random.Next(0, numbers.Count)];
            }

            return URL;
        }
    }
}
