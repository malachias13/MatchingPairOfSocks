using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SockInDark
{
    /*Socks in the Dark:
    There are 20 socks in a drawer: 5 pairs of black, 3 pairs of brown, and 2 pairs of white.
    You select the socks in the dark and can check them only after a selection has been made. 

    What is the smallest number of socks you need to select to guarantee you get the following:
    At least one matching pair.
    At least one matching pair of each color.

     */

    public class SockFinderSim
    {
        List<string> Socks = new List<string>();
        int totalNumberSocks;
        int currentNumberSocks;
        int position = 0;

        int blackSocks;
        int brownSocks;
        int whiteSocks;

        Random rand = new Random();
        public void SuffileSocks(int black, int brown, int white)
        {
            int timesToLoop = 0;
            int colorSocks = black;
            string item = string.Empty;
            // add sock to list
            totalNumberSocks = black + brown + white;
            for(int a = 0; a != 3;a++)
            {
                switch (timesToLoop)
                {
                    case 0:
                        colorSocks = black;
                        item = "Black";
                        break;
                    case 1:
                        colorSocks = brown;
                        item = "Brown";
                        break;
                    case 2:
                        colorSocks = white;
                        item = "White";
                        break;
                }
                for(int t = 0; t != colorSocks; t++)
                {
                    Socks.Add(item);
                }
                timesToLoop++;
            }
            // Print Unrandomize  Array 
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("UnRandomize Array\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string e in Socks)
            {
                Console.Write(e + ", ");
            }


            // Randomize list
            for(int i = 0; i < totalNumberSocks;i++)
            {
                int randPosition = rand.Next(i, totalNumberSocks);
                // using item as a temp variable
                item = Socks[i];
                Socks[i] = Socks[randPosition];
                Socks[randPosition] = item;
            }

            // Print Randomize Array
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nRandomize Array");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string d in Socks)
            {
                Console.Write(d + ", ");
            }
            Console.WriteLine("\n");

        }
        
        public void BlindSockSelection()
        {
            List<string> SocksPicked = new List<string>();

            for(int i = 0; i < totalNumberSocks - 1; i++)
            {
                SocksPicked.Add(Socks[i]);
                SocksPicked.Add(Socks[i + 1]);

                if (SocksPicked.Contains("Black"))
                    blackSocks += 1;
                if (SocksPicked.Contains("Brown"))
                    brownSocks += 1;
                if (SocksPicked.Contains("White"))
                    whiteSocks += 1;

                if(blackSocks == 2)
                {
                    Console.WriteLine("Found Black pair: total socks selected {0}", SocksPicked.Count);
                }
                if (brownSocks == 2)
                {
                    Console.WriteLine("Found Brown pair: total socks selected {0}", SocksPicked.Count);
                }
                if (whiteSocks == 2)
                {
                    Console.WriteLine("Found White pair: total socks selected {0}", SocksPicked.Count);
                }

                if(blackSocks >= 2 && brownSocks >= 2 && whiteSocks >= 2)
                {
                    Console.WriteLine("\nFound one pair of socks for each color: total of socks selected {0}", SocksPicked.Count);
                    break;
                }
            }
        }
    }
}
