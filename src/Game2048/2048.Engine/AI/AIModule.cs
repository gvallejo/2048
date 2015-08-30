using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.AI
{
    public class AIModule: IAIModule
    {
        private ITileGenerator _tileGenerator = null;
        protected Random m_rand;

        public AIModule(ITileGenerator tileGenerator)
        {
            this._tileGenerator = tileGenerator;
            this.m_rand = new Random();
        }

        public void GenerateRandomTile(ref IBoard board)
        {
            int pickedTile;
            int tileValue;

            pickedTile = this.m_rand.Next(0, board.BlankTiles.Count);
            tileValue = this._tileGenerator.GetNextTile();

            board.SetTile(board.BlankTiles[pickedTile].Item1, board.BlankTiles[pickedTile].Item2, tileValue);
        }

        public bool IsGameOver(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
