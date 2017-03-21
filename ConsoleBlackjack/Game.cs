using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Game
    {
        Deck d;

        public Game()
        {
            Setup();
            // String result = Round();
        }

        public String Round()
        {
            List<String> playerHand = new List<String>();
            List<String> dealerHand = new List<String>();
            // Add two cards to the player's hand
            playerHand.Add(d.NextCard());
            playerHand.Add(d.NextCard());
            // Calculate the (estimated) value of the player's hand
            var PlayerHandVal = PrintHand(playerHand, "Player");
            if (PlayerHandVal == 21)
            {
                Blackjack();
                return "Blackjack";
            }

            // Add one card to dealer's hand, and print, before adding another card.
            Console.WriteLine();
            dealerHand.Add(d.NextCard());
            PrintHand(dealerHand, "Dealer");
            Console.WriteLine();
            dealerHand.Add(d.NextCard());

            // With the knowledge of the one of the dealer's cards, the player begins their turn 
            PlayerHandVal = handlePlayer(playerHand, PlayerHandVal);
            if (PlayerHandVal > 21)
            {
                Console.WriteLine("Unfortunately you busted. Better luck next time.");
                return "Bust";
            }

            var DealerHandVal = handleDealer(dealerHand);
            if (DealerHandVal > 21)
            {
                Console.WriteLine("Dealer has busted. Player wins!");
                return "Dealer Bust";
            }

            if (PlayerHandVal == DealerHandVal)
            {
                Console.WriteLine("Tie. All money is returned.");
            } else if (PlayerHandVal > DealerHandVal)
            {
                Console.WriteLine("Player wins!");
            } else
            {
                Console.WriteLine("Dealer wins.");
            }
            return "OK";
        }

        public int handleDealer(List<String> dealerHand)
        {
            var DealerHandVal = PrintHand(dealerHand, "Dealer");
            if (DealerHandVal == 21)
            {
                return 21;
            }
            while (DealerHandVal <= 21 && DealerHandVal < 17)
            {
                dealerHand.Add(d.NextCard());
                DealerHandVal = PrintHand(dealerHand, "Dealer");
            }
            return DealerHandVal;
        }

        public int handlePlayer(List<String> playerHand, int PlayerHandVal)
        {
            while (PlayerHandVal <= 21)
            {
                Console.Write("Would you like to {h}it or {s}tand? ");
                var answer = Console.ReadLine();
                if (answer == "h" || answer == "H")
                {
                    playerHand.Add(d.NextCard());
                    PlayerHandVal = PrintHand(playerHand, "Player");
                }
                else
                {
                    return PlayerHandVal;
                }
            }
            return PlayerHandVal;
        }

        public void Blackjack()
        {
            Console.WriteLine("Ayy that's a BlackJack!\nUhh, we just say Blackjack.");
        }

        public int PrintHand(List<String> hand, String owner)
        {
            Console.WriteLine($"The {owner} has the following cards:");
            foreach (var c in hand)
            {
                var val = CardValue(c);
                Console.WriteLine($"{c} with a value of {val}");
            }
            var handVal = GetValue(hand);
            Console.WriteLine($"The estimated value of this hand is {handVal}");
            return handVal;
        }

        public String CardValue(String s)
        {
            var val = s[1];
            if (val == 'A')
            {
                return "1 or 11";
            } else if (val == 'J' || val == 'Q' || val == 'K' || val == '1' )
            {
                return "10";
            } else
            {
                return val + "";
            }
        }

        public int GetValue(List<String> hand)
        {
            int curr = 0;
            int aces = 0;
            foreach (var c in hand)
            {
                var val = c[1];
                if (val == 'A')
                {
                    curr += 11;
                    aces++;
                }
                else if (val == 'J' || val == 'Q' || val == 'K' || val == '1')
                {
                    curr += 10;
                }
                else
                {
                    curr += Int32.Parse(val + "");
                }
            }
            while (curr > 21 && aces > 0)
            {
                curr -= 10;
                aces--;
            }
            return curr;
        }

        public void Setup()
        {
            d = new Deck();
        }
    }
}
