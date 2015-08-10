using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsClient.DependencyInjection;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        IGameEngine _gameEngine;
        
        Label[,] _labels; 
        

        public Form1()
        {
            InitializeComponent();
            IoC.IoC.Initialize(new DependencyResolver());

            InitializeBoard();

            _gameEngine = IoC.IoC.Resolve<IGameEngine>();
            _gameEngine.Output.OnBoardChange += Output_OnBoardChange;
            _gameEngine.NewGame();
           
            //Initializing some tiles
            _gameEngine.SetTile(0, 0, 2); _gameEngine.SetTile(0, 1, 2); _gameEngine.SetTile(0, 2, 0); _gameEngine.SetTile(0, 3, 4);
            _gameEngine.SetTile(1, 0, 4); _gameEngine.SetTile(1, 1, 2); _gameEngine.SetTile(1, 2, 4); _gameEngine.SetTile(1, 3, 4);
            _gameEngine.SetTile(2, 0, 2); _gameEngine.SetTile(2, 1, 2); _gameEngine.SetTile(2, 2, 0); _gameEngine.SetTile(2, 3, 2);
        }

        void Output_OnBoardChange(object sender, EventArgs args)
        {
            int[,] tiles = (int[,])sender;
            PaintBoard(tiles);
        }


        private void PaintBoard(int[,] tiles)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i, j] == 0)
                        _labels[i, j].Text = string.Empty;
                    else
                        _labels[i, j].Text = tiles[i, j].ToString();
                }
            }
        }

        private void InitializeBoard()
        {
            _labels = new Label[4, 4]
            {
                {this.label1, this.label2, this.label3, this.label4},
                {this.label5, this.label6, this.label7, this.label8},
                {this.label9, this.label10, this.label11, this.label12},
                {this.label13, this.label14, this.label15, this.label16},

            };

            foreach (var label in _labels)
            {
                label.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gameEngine.Input.Move(MoveDirection.UP);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _gameEngine.Input.Move(MoveDirection.LEFT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gameEngine.Input.Move(MoveDirection.RIGHT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _gameEngine.Input.Move(MoveDirection.DOWN);
        }
        
    }
}
