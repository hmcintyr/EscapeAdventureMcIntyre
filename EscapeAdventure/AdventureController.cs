using System;
using System.IO;
using System.Text.Json;

namespace EscapeAdventure
{
    public class AdventureController
    {
        private Dungeon _dungeon;
        private Adventurer _adventurer;
        private Room _currentRoom;

        public void Start()
        {

            string adventureString = File.ReadAllText("EscapeAdventure.json");
            _dungeon = JsonSerializer.Deserialize<Dungeon>(adventureString);
            _currentRoom = _dungeon.Rooms["blue room"];
            


            bool continueAdventure = true;

            while (continueAdventure)
            {
                string actionText;
                string itemText;

                string phrase = Console.ReadLine();
                phrase = phrase.Trim();
                phrase = phrase.ToLower();

                if (phrase.IndexOf(' ') == -1)
                {
                    actionText = phrase;
                    itemText = "";
                }
                else
                {
                    actionText = phrase.Substring(0, phrase.IndexOf(' '));
                    itemText = phrase.Substring(phrase.IndexOf(' ') + 1);
                }
                    
               

                switch (actionText.ToLower())
                {
                    case "go":
                        Go(itemText);
                        break;
                    case "quit":
                        continueAdventure = false;
                        break;
                    case "example":
                        Examples(itemText);
                        break;
                    default:
                        break;
                }
            }

            Credits();
        }

        void Examples(string text)
        {
            Console.WriteLine(_dungeon.Rooms["blue room"].Description + "\n\n");
            Console.WriteLine(_dungeon.Rooms["red room"].Items["candles"].Description + "\n\n");
            Console.WriteLine(_dungeon.Rooms["yellow room"].Doors["east"].NextRoom + "\n\n");

            //Checking if door exists.
            if (_currentRoom.Doors.ContainsKey(text.ToLower()))
            {
                Console.WriteLine(text + " exists\n");
            }
            else
            {
                Console.WriteLine("Huh?\n");
            }


            //Example for picking up an item in a room.
            if (_currentRoom.Items.ContainsKey(text.ToLower()))
            {
                _adventurer.Items.Add(text.ToLower(), _currentRoom.Items[text]);
                _currentRoom.Items.Remove(text.ToLower());
            }
            else
            {
                Console.WriteLine("Can not do that.\n");
            }
        }
        void Go (string direction)
        {
            Console.WriteLine(direction + "\n");
            string nextRoom = _currentRoom.Doors[direction].NextRoom;
            Console.WriteLine(nextRoom + "\n");
        }



        void Credits()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            
        }
    }
}
