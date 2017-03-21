using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Blackjack!");
            Game g = new ConsoleBlackjack.Game();
            g.Round();
            while (true)
            {
                Console.WriteLine();
                Console.Write("Play again? (Y/N) ");
                String response = Console.ReadLine();
                if (response == "y" || response == "Y")
                {
                    g.Round();
                } else
                {
                    return;
                }
            }
        }
    }
}
