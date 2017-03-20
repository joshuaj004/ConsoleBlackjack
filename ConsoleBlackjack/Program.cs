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
            Deck d = new Deck();
            Console.WriteLine(d.NextCard());
            Console.WriteLine(d.NextCard());
            Console.WriteLine(d.NextCard());
            Console.WriteLine(d.NextCard());
            Console.WriteLine(d.NextCard());
        }
    }
}
