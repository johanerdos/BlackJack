using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player
    {
        private double _wallet;
        private string _name;
        private int _age;

        public Player(string _name, int _age, double _wallet)
        {
            Wallet = _wallet;
            Name = _name;
            Age = _age;
        }

        public Player()
        {

        }

        public double Wallet 
        {
            get { return _wallet; }
            set { _wallet = value; }
        }
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age 
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
