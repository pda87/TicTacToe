using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Square
    {
        public PlayerInformation Player { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public Square(PlayerInformation playerInfo)
        {
            this.Player = playerInfo;
        }
    }

    public enum PlayerInformation
    {
        Default,
        Player1,
        Player2
    }
}
