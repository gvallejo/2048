using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public unsafe struct TilesBuffer
    {
        
        public fixed int fixedBuffer[16];
    } 

    public unsafe class Board: IBoard
    {
        const int ROWS = 4;
        const int COLS = 4;

        private TilesBuffer tilesBuffer = default(TilesBuffer);// = new int[ROWS, COLS];

       // private readonly int[,] _tiles = new int[4, 4];

        protected List<ITileAccessor> _rowsLeftToRight;
        protected List<ITileAccessor> _rowsRightToLeft;
        protected List<ITileAccessor> _colsTopDown;
        protected List<ITileAccessor> _colsBottomUp;

        public Board()
        {
            SiAuto.Main.LogMessage("Board ctor()");
            this._rowsLeftToRight = new List<ITileAccessor>(4);
            this._rowsRightToLeft = new List<ITileAccessor>(4);
            this._colsTopDown = new List<ITileAccessor>(4);
            this._colsBottomUp = new List<ITileAccessor>(4);

            PointRowsAndColsToArrayElements(this._rowsLeftToRight, ReadDirection.LeftToRight, ref this.tilesBuffer);
            PointRowsAndColsToArrayElements(this._rowsRightToLeft, ReadDirection.RightToLeft, ref this.tilesBuffer);
            PointRowsAndColsToArrayElements(this._colsTopDown, ReadDirection.TopDown, ref this.tilesBuffer);
            PointRowsAndColsToArrayElements(this._colsBottomUp, ReadDirection.BottomUp, ref this.tilesBuffer);

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

        public List<Tuple<int, int>> BlankTiles
        {
            get 
            {
                int r, c;
                List<Tuple<int, int>> blankTiles = new List<Tuple<int, int>>();

                fixed (int* pSrc = tilesBuffer.fixedBuffer)
                {
                    for (int i = 0; i < 16; i++)
                    {
                       if(pSrc[i] == 0)
                       {
                           r = i / 4;
                           c = i % 4;
                           blankTiles.Add(new Tuple<int, int>(r, c));
                       }
                    }
                }

                return blankTiles;
            }
        }

        public int[,] Tiles
        {
            get
            {
                int[,] tiles = new int[4, 4];
                fixed (int* pDest = &tiles[0, 0])
                fixed (int* pSrc = tilesBuffer.fixedBuffer)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        *(pDest + i) = *(pSrc + i);
                    }
                }

                return tiles;
            }
            
        }

        public void SetTiles(int[,] tiles)
        {
            SiAuto.Main.EnterMethod(this, "SetTiles");
            try
            {
                /*--------- Your code goes here-------*/

                fixed (int* pSrc = &tiles[0,0])
                fixed (int* pDest = tilesBuffer.fixedBuffer)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        pDest[i] = pSrc[i];
                    }
                }

                if (tiles == null)
                    throw new ArgumentNullException("tiles");
                
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

        public void SetTile(int r, int c, int value)
        {
            SiAuto.Main.EnterMethod(this, "SetTile");
            try
            {
                /*--------- Your code goes here-------*/

                
                fixed (int* pDest = tilesBuffer.fixedBuffer)
                {
                   
                        pDest[(4*r)+c] = value;
                    
                }

               

                /*------------------------------------*/
            }
            catch (Exception ex)
            {
                SiAuto.Main.LogException(ex);
                throw ex;
            }
            finally
            {
                SiAuto.Main.LeaveMethod(this, "SetTile");
            }

        }

        public List<ITileAccessor> RowsLeftToRight
        {
            get 
            {
                PointRowsAndColsToArrayElements(this._rowsLeftToRight, ReadDirection.LeftToRight, ref this.tilesBuffer);
                
                return _rowsLeftToRight; 
            
            }
        }

        public List<ITileAccessor> RowsRightToLeft
        {
            get {
                
                PointRowsAndColsToArrayElements(this._rowsRightToLeft, ReadDirection.RightToLeft, ref this.tilesBuffer);
                
                return _rowsRightToLeft; }
        }

        public List<ITileAccessor> ColsTopDown
        {
            get {
               
                PointRowsAndColsToArrayElements(this._colsTopDown, ReadDirection.TopDown, ref this.tilesBuffer);
                
                return _colsTopDown;
            }
        }

        public List<ITileAccessor> ColsBottomUp
        {
            get {
                
                PointRowsAndColsToArrayElements(this._colsBottomUp, ReadDirection.BottomUp, ref this.tilesBuffer);
                return _colsBottomUp; }
        }

        /// <summary>
        /// Sets _rows and _cols collections to point to _tiles[,] elements
        /// </summary>
        private void PointRowsAndColsToArrayElements(List<ITileAccessor> tileAccessorCollection,  ReadDirection readDirection, ref TilesBuffer buffer)
        {            
                for (int i = 0; i < 4; i++)
                {
                    if (tileAccessorCollection.Count < 4)                    
                        tileAccessorCollection.Add(new TileAccessor(i, readDirection, ref buffer));                    
                    else
                        tileAccessorCollection[i].AttachToTiles(ref buffer);
                }
            
        }





       
    }
}
