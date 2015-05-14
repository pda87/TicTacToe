using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Game
    {
        public bool playerTurn { get; set; }
        public int Box { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool GameOver { get; set; }
        public string ResultString { get; set; }

        public Game()
        {
            this.playerTurn = false;
            this.GameOver = false;
            this.Player1 = new Player();
            this.Player1.Name = "Player 1";
            this.Player2 = new Player();
            this.Player2.Name = "Player 2";
        }

        public void playGame()
        {

            if (this.GameOver)
            {
                checkVerticalLine(this.Player1);
                checkVerticalLine(this.Player2);
                checkHorizontalLine(this.Player1);
                checkHorizontalLine(this.Player2);

                if (this.Player1.PlayerWins && this.Player2.PlayerWins)
                {
                    ResultString = "Draw...";
                }

                if (!this.Player1.PlayerWins && !this.Player2.PlayerWins)
                {
                    ResultString = "Nobody wins...";
                }

            }

            if (this.playerTurn)
            {
                this.Box = 0;
                this.playerTurn = false;
            }

            else
            {
                this.playerTurn = true;
            }
        }

        private void checkVerticalLine(Player player)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (player.SquareList.Count(square => square.xCoordinate.Equals(i)) == 3)
                {
                    List<Square> equalXCoordinates = (from square in player.SquareList
                                                     where square.xCoordinate.Equals(i)
                                                     select square).OrderByDescending(square => square.yCoordinate).ToList();

                    if (equalXCoordinates[0].yCoordinate == 2 && equalXCoordinates[1].yCoordinate == 1 && equalXCoordinates[2].yCoordinate == 0)
                    {
                        this.ResultString = player.Name + " wins!";
                        player.PlayerWins = true;
                        return;
                    }
                }
            }
        }

        private void checkHorizontalLine(Player player)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (player.SquareList.Count(square => square.yCoordinate.Equals(i)) == 3)
                {
                    List<Square> equalYCoordinates = (from square in player.SquareList
                                                      where square.yCoordinate.Equals(i)
                                                      select square).OrderByDescending(square => square.xCoordinate).ToList();

                    if (equalYCoordinates[0].xCoordinate == 2 && equalYCoordinates[1].xCoordinate == 1 && equalYCoordinates[2].xCoordinate == 0)
                    {
                        this.ResultString = player.Name + " wins!";
                        player.PlayerWins = true;
                        return;
                    }
                }
            }


        }
    }
}
