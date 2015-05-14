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

        public Player()
        {
            this.SquareList = new List<Square>();
        }
    }
}
