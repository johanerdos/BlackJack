using System;
using System.Collections.Generic;

namespace BlackJack
{

    public class Program
    {
        
        static void Main(string[] args)
        {
            bool cont = true;
            Console.WriteLine("Name...?");
            string name = Console.ReadLine();

            Console.WriteLine("Age...?");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How much would you like to spend?");
            double wallet = Convert.ToDouble(Console.ReadLine());

            Player player = new Player(name, age, wallet);

            Console.WriteLine("Name {0}, Age {1}, Wallet {2}", name, age, wallet);

            while (cont)
            {
                Console.WriteLine("Current wallet = " + player.Wallet);
                Console.WriteLine("Place your bet...");
                double bet = Convert.ToDouble(Console.ReadLine());

                int playerNumber = 0;
                int dealerNumber = 0;
                Card card = new Card();
                List<Card> playerHand = new List<Card>();
                List<Card> dealerHand = new List<Card>();

                
                //filling player hand
                for (int i = 0; i < 2; i++)
                {
                    Card c = card.PrintCard();
                    playerHand.Add(c);
                }

                foreach (Card card1 in playerHand)
                {
                    playerNumber += card1.Number;
                }
                Console.WriteLine(playerNumber);

                //filling dealer hand
                Card dealerCard = card.PrintCard();
                dealerHand.Add(dealerCard);
                dealerNumber = dealerCard.Number;
                Console.WriteLine(dealerNumber);


                if (playerNumber == 21)
                {
                    Winner(playerNumber, dealerNumber);
                    wallet += (bet + bet / 2);
                    cont = Continue();
                    if (cont == true)
                    {
                        ResetHand(playerHand, dealerHand);

                    }
                    else
                    {
                        break;
                    }
                }

                else
                {

                    
                    while (playerNumber < 21)
                    {
                        string decision = CheckInput();
                        if (decision.Equals("hit"))
                        {
                            Card c = Hit();
                            playerNumber += c.Number;
                            Console.WriteLine(playerNumber);
                        }
                        else
                        {
                            break;
                        }

                    }
                    dealerNumber = Stay(dealerHand, dealerNumber);
                    player.Wallet = CheckScore(playerNumber, dealerNumber, wallet, bet);
                    cont = Continue();
                    if (cont == true)
                    {
                        ResetHand(playerHand, dealerHand);
                    }
                    else
                    {
                        break;
                    }


                }
            }
        }

        
        static Card Hit()
        {
            Card c = new Card();
            Card card = c.PrintCard();
            return card;
        }

        static int Stay(List<Card> dealerHand, int dealerNumber)
        {
            Card card = null;
            

            while (dealerNumber < 17)
            {
                Card c = new Card();
                card = c.PrintCard();
                dealerHand.Add(card);

                foreach (Card cards in dealerHand)
                {
                    dealerNumber += cards.Number;
                }
                if (dealerNumber > 17)
                {
                    break;
                }
            }

            return dealerNumber;
        }
        static string CheckInput()
        {
            Console.WriteLine("Hit or stay?");
            string decision = Console.ReadLine();
            return decision;
        }

        static void Winner(int playerNumber, int dealerNumber)
        {
            if (playerNumber == 21)
            {
                Console.WriteLine("You got blackjack, player wins");
                
                
            }
            else
            {
                Console.WriteLine("You won, your score was: " + playerNumber);
                Console.WriteLine("Dealer score was: " + dealerNumber);
                
            }
        }

        static void Loser(int pNumber, int dNumber)
        {
            Console.WriteLine("You lose. Player score: " + pNumber);
            Console.WriteLine("Dealer score: " + dNumber);
            
        }

        static bool Continue()
        {
            Console.WriteLine("Play again? Y/N");
            string cont = Console.ReadLine();
            if (cont.ToLower().Equals("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ResetHand(List<Card> playerHand, List<Card> dealerHand)
        {
            for (int i = 0; i < playerHand.Count; i++)
            {
                playerHand.RemoveAt(i);
                for (int j = 0; j < dealerHand.Count; i++)
                {
                    dealerHand.RemoveAt(j);
                }
            }
        }

        static double CheckScore(int playerNumber, int dealerNumber, double wallet, double bet)
        {
            
            if(playerNumber > 21)
            {
                Loser(playerNumber, dealerNumber);
                wallet -= bet;

            }else if(dealerNumber > playerNumber && dealerNumber < 21)
            {
                Loser(playerNumber, dealerNumber);
                wallet -= bet;

            }else if(playerNumber > dealerNumber)
            {
                Winner(playerNumber, dealerNumber);
                wallet += bet;

            }else if(dealerNumber > 21)
            {
                Winner(playerNumber, dealerNumber);
                wallet += bet;
            }
            return wallet;

        }


    }
}

