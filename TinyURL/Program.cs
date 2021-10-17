using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TinyURL!");
            ConsoleInterface UI = new ConsoleInterface();
            UI.ShowOptions();
        }

    }
}
