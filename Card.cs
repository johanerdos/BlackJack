using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Card
    {
        private string _suite;
        private int _number;
        private string _color;
        private string _rank;
        
        public Card(string _suite, string _rank, string _color, int _number)
        {
            Suite = _suite;
            Rank = _rank;
            Color = _color;
            Number = _number;
        }

        public Card()
        {

        }
        public string Suite
        {
            get { return _suite; }
            set { _suite = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        

        public Card PrintCard()
        {
            string[] rank = new string[] { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };
            string[] color = new string[] { "Red", "Black" };
            string[] suite = new string[] { "Hearts", "Clubs", "Spades", "Diamonds" };
            int[] numbers = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rand = new Random();
            int indexRank = rand.Next(0, rank.Length);
            int indexColor = rand.Next(0, color.Length);
            int indexSuite = rand.Next(0, suite.Length);

            string r = rank[indexRank];
            string c = color[indexColor];
            string s = suite[indexSuite];

            int number = 0;

            if(r.Equals("A") || r.Equals("K") || r.Equals("Q") || r.Equals("J"))
            {

                number = ConvertRank(r);
            }
            else
            {
                number = Convert.ToInt32(r.ToString());
            }

            Card card1 = new Card(s, r, c, number);

            return card1;
        }

        public int ConvertRank(string rank)
        {
            int number = 0;
            if (rank.Equals("A"))
            {
                number = 11;
            }
            if(rank.Equals("K") || rank.Equals("Q") || rank.Equals("J"))
            {
                number = 10;
            }

            return number;
        }
    }
}
