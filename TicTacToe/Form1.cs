using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        static List<PictureBox> pictureBoxList;
        static List<int> intList = new List<int>();

        static Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxList = new List<PictureBox>()
            {
                zeroZero, oneZero, twoZero, zeroOne, oneOne,
                twoOne, zeroTwo, oneTwo, twoTwo
            };

            game = new Game();
            aiTurn();
        }


        private void zeroZero_Click(object sender, EventArgs e)
        {
            displayTurn(zeroZero, @"Logos/oO.png", 0, 0, 0);
        }

        private void oneZero_Click(object sender, EventArgs e)
        {
            displayTurn(oneZero, @"Logos/oO.png", 1, 1, 0);
        }

        private void twoZero_Click(object sender, EventArgs e)
        {
            displayTurn(twoZero, @"Logos/oO.png", 2, 2, 0);
        }

        private void zeroOne_Click(object sender, EventArgs e)
        {
            displayTurn(zeroOne, @"Logos/oO.png", 3, 0, 1);
        }

        private void oneOne_Click(object sender, EventArgs e)
        {
            displayTurn(oneOne, @"Logos/oO.png", 4, 1, 1);
        }

        private void twoOne_Click(object sender, EventArgs e)
        {
            displayTurn(twoOne, @"Logos/oO.png", 5, 2, 1);
        }

        private void zeroTwo_Click(object sender, EventArgs e)
        {
            displayTurn(zeroTwo, @"Logos/oO.png", 6, 0, 2);
        }

        private void oneTwo_Click(object sender, EventArgs e)
        {
            displayTurn(oneTwo, @"Logos/oO.png", 7, 1, 2);
        }

        private void twoTwo_Click(object sender, EventArgs e)
        {
            displayTurn(twoTwo, @"Logos/oO.png", 8, 2, 2);
        }

        private void displayTurn(PictureBox pictureBox, string imageLocation, int pbClicked, int xCoordinate, int yCoordinate)
        {
            resultLabel.Text = "";

            if (game.Player1.SquareList.Count(sq => sq.xCoordinate.Equals(xCoordinate) && sq.yCoordinate.Equals(yCoordinate)) == 1
                || game.Player2.SquareList.Count(sq => sq.xCoordinate.Equals(xCoordinate) && sq.yCoordinate.Equals(yCoordinate)) == 1)
            {
                resultLabel.Text = "Invalid square";
                return;
            }

            if (!game.GameOver)
            {
                if (!intList.Contains(pbClicked))
                {
                    intList.Add(pbClicked);

                    game.Player1.SquareList.Add(new Square(PlayerInformation.Player1) { xCoordinate = xCoordinate, yCoordinate = yCoordinate });

                    pictureBox.ImageLocation = imageLocation;
                    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBox.Refresh();
                }

                aiTurn();
            }
        }

        private void aiTurn()
        {
            if (intList.Count <= 8)
            {
                Random random = new Random();
                game.Box = random.Next(0, 8);

                if (intList.Contains(game.Box))
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (!intList.Contains(i))
                        {
                            game.Box = i;
                            break;
                        }

                    }
                    intList.Add(game.Box);
                    int[] coordinates = getCoordinates();
                    game.Player2.SquareList.Add(new Square(PlayerInformation.Player2) { xCoordinate = coordinates[0], yCoordinate = coordinates[1] });
                    pictureBoxList[game.Box].ImageLocation = @"Logos/xX.png";
                    pictureBoxList[game.Box].SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBoxList[game.Box].Refresh();
                    game.playGame();
                }

                else
                {
                    intList.Add(game.Box);
                    int[] coordinates = getCoordinates();
                    game.Player2.SquareList.Add(new Square(PlayerInformation.Player2) { xCoordinate = coordinates[0], yCoordinate = coordinates[1] });
                    pictureBoxList[game.Box].ImageLocation = @"Logos/xX.png";
                    pictureBoxList[game.Box].SizeMode = PictureBoxSizeMode.AutoSize;
                    pictureBoxList[game.Box].Refresh();
                    game.playGame();
                }

            }
            if (game.Player1.SquareList.Count() + game.Player2.SquareList.Count == 9)
            
            {
                game.GameOver = true;
                pictureBoxList.ForEach(pb => pb.Enabled = false);
                game.playGame();
                resultLabel.Text = game.ResultString;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            game = new Game();
            game.playerTurn = true;
            pictureBoxList.ForEach(pb => pb.ImageLocation = "");
            pictureBoxList.ForEach(pb => pb.Enabled = true);
            intList.Clear();
            resultLabel.Text = "";
        }

        private int[] getCoordinates()
        {
            int[] coordinates = new int[2];

            if (game.Box == 0)
            {
                coordinates[0] = 0;
                coordinates[1] = 0;
            }

            else if (game.Box == 1)
            {
                coordinates[0] = 1;
                coordinates[1] = 0;
            }

            else if (game.Box == 2)
            {
                coordinates[0] = 2;
                coordinates[1] = 0;
            }

            else if (game.Box == 3)
            {
                coordinates[0] = 0;
                coordinates[1] = 1;
            }

            else if (game.Box == 4)
            {
                coordinates[0] = 1;
                coordinates[1] = 1;
            }

            else if (game.Box == 5)
            {
                coordinates[0] = 2;
                coordinates[1] = 1;
            }

            else if (game.Box == 6)
            {
                coordinates[0] = 0;
                coordinates[1] = 2;
            }

            else if (game.Box == 7)
            {
                coordinates[0] = 1;
                coordinates[1] = 2;
            }

            else if (game.Box == 8)
            {
                coordinates[0] = 2;
                coordinates[1] = 2;
            }

            return coordinates;

        }
    }
}
