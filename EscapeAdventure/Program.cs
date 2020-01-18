using System;
using System.IO;
using System.Text.Json;

namespace EscapeAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Escape Adventure");

            AdventureController ac = new AdventureController();
            ac.Start();

                       

        }
    
    }
}
