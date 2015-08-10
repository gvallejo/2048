using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public class Board: IBoard
    {
        const int ROWS = 4;
        const int COLS = 4;

        protected int[,] _tiles;// = new int[ROWS, COLS];

        protected List<List<int>> _rows;
        protected List<List<int>> _cols;

        public Board()
        {
            this._rows = new List<List<int>>(4) { new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 } };
            this._cols = new List<List<int>>(4) { new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0 } };

             int[,] tiles = new int[4, 4]
                {
                    {0,  0,  0,  0},
                    {0,  0,  0,  0},
                    {0,  0,  0,  0},
                    {0,  0,  0,  0}
        
                };

             SetTiles(tiles);
        }

        public Board(int[,] tiles):this()
        {                        
            SetTiles(tiles);
        }


        public int[,] Tiles
        {
            get
            {
                return _tiles;
            }
            
        }

        public void SetTiles(int[,] tiles)
        {
            SiAuto.Main.EnterMethod(this, "SetTiles");
            try
            {
                /*--------- Your code goes here-------*/
                if (tiles == null)
                    throw new ArgumentNullException("tiles");
                _tiles = tiles;
                PointRowsAndColsToArrayElements();
                /*------------------------------------*/
            }
            catch (Exception ex)
            {
                SiAuto.Main.LogException(ex);
                throw ex;
            }
            finally
            {
                SiAuto.Main.LeaveMethod(this, "SetTiles");
            }

        }

        public List<List<int>> Rows
        {
            get { return _rows; }
        }

        public List<List<int>> Cols
        {
            get { return _cols; }
        }

        /// <summary>
        /// Sets _rows and _cols collections to point to _tiles[,] elements
        /// </summary>
        private void PointRowsAndColsToArrayElements()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    _rows[i][j] = _tiles[i, j];
                    _cols[j][i] = _tiles[i, j];
                }
            }
        }


        
    }
}
