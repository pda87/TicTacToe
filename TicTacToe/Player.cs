using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        public string Name { get; set; }
        public List<Square> SquareList { get; set; }
        public bool PlayerWins { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.SquareList = new List<Square>();
        }
    }
}
