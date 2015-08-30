using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public class MoveProcessor: IMoveProcessor
    {
        public MoveProcessor(IBoard board)
        {
            this.Board = board;
        }

        public MoveProcessor()
        {

        }

        public IBoard Board { get;  set; }
        

        public void ProcessMove(MoveDirection move)
        {
           
            
            switch (move)
            {
                case MoveDirection.UP:
                    ProcessMove(this.Board.ColsTopDown);
                    break;
                case MoveDirection.DOWN:
                    ProcessMove(this.Board.ColsBottomUp);
                    break;
                case MoveDirection.LEFT:
                    ProcessMove(this.Board.RowsLeftToRight);
                    break;
                case MoveDirection.RIGHT:
                    ProcessMove(this.Board.RowsRightToLeft);
                    break;
                default:
                    break;
            }
            SiAuto.Main.LogMessage("first element : {0}", this.Board.RowsLeftToRight[0][0]);
            SiAuto.Main.LogMessage(string.Join<Tuple<int,int>>(" tile:", this.Board.BlankTiles));
        }

        protected void ProcessMove(List<ITileAccessor> tilesAccessors)
        {
            int r = 0, w =0;
            
            foreach (var tilesAccessor in tilesAccessors)
            {
                //intialize r(read) w(write) pointers
                r = w = 0;
                while (r < 4)
                {
                    if (r == w)
                    {
                        r++;
                        continue;
                    }
                    else if ((tilesAccessor[r] == 0) || (tilesAccessor[w] == 0))
                    {
                        tilesAccessor[w] = tilesAccessor[r] + tilesAccessor[w];
                        tilesAccessor[r] = 0;
                        r++;
                        continue;
                    }
                    else if (tilesAccessor[r] == tilesAccessor[w])
                    {
                        tilesAccessor[w] = tilesAccessor[r] + tilesAccessor[w];
                        tilesAccessor[r] = 0;
                        w++;
                    }
                    else
                        w++;
                }
            }

        }

        protected void ProcessLeftMove()
        {
            //special collection that stacks items according to 2048 rules
            Stack2048 stack2048 = new Stack2048(4);

            // for each row
            for (int i = 0; i < 4; i++)
            {
                //clear special collection
                stack2048.Clear();

                //for each element in row 
                for (int j = 0; j < 4; j++)
                {
                    if (this.Board.Tiles[i, j] != 0)
                        stack2048.SpecialPush2048(this.Board.Tiles[i, j]);
                    //clear the tiles in the row
                    this.Board.Tiles[i, j] = 0;
                }
                int[] processedrow = stack2048.ToArray();
                int jj = 0;
                int s = stack2048.Count - 1;
                while (s >= 0)
                {
                    this.Board.Tiles[i, jj] = processedrow[s];
                    s--;
                    jj++;
                }               
            }
        }

        protected void ProcessRightMove()
        {
            //special collection that stacks items according to 2048 rules
            Stack2048 stack2048 = new Stack2048(4);

            // for each row
            for (int i = 0; i < 4; i++)
            {
                //special collection that stacks items according to 2048 rules
                stack2048.Clear();

                //for each element in row 
                for (int j = 4 - 1; j >= 0; j--)                
                {
                    if (this.Board.Tiles[i, j] != 0)
                        stack2048.SpecialPush2048(this.Board.Tiles[i, j]);
                    //clear the tiles in the row
                    this.Board.Tiles[i, j] = 0;
                }
                int[] processedrow = stack2048.ToArray();
                int jj = 3; 
                int s = stack2048.Count - 1;
                while (s >=0)
                {                                   
                    this.Board.Tiles[i, jj] = processedrow[s];
                    s--;
                    jj--;
                }
            }
        }

        protected void ProcessDownMove()
        {
            //special collection that stacks items according to 2048 rules
            Stack2048 stack2048 = new Stack2048(4);

            // for each col
            for (int j = 0; j < 4; j++)
            {
                //clear special collection
                stack2048.Clear();

                //for each element in col 
                for (int i = 3; i >= 0; i--)
                {
                    if (this.Board.Tiles[i, j] != 0)
                        stack2048.SpecialPush2048(this.Board.Tiles[i, j]);
                    //clear the tiles in the row
                    this.Board.Tiles[i, j] = 0;
                }
                int[] processedrow = stack2048.ToArray();
                int ii = 3;
                int s = stack2048.Count - 1;
                while (s >= 0)
                {
                    this.Board.Tiles[ii, j] = processedrow[s];
                    s--;
                    ii--;
                }
            }
        }

        protected void ProcessUpMove()
        {
            //special collection that stacks items according to 2048 rules
            Stack2048 stack2048 = new Stack2048(4);

            // for each col
            for (int j = 0; j < 4; j++)
            {
                //clear special collection that stacks items according to 2048 rules
                stack2048.Clear();

                //for each element in col 
                for (int i = 0; i < 4; i++)                
                {
                    if (this.Board.Tiles[i, j] != 0)
                        stack2048.SpecialPush2048(this.Board.Tiles[i, j]);
                    //clear the tiles in the row
                    this.Board.Tiles[i, j] = 0;
                }
                int[] processedrow = stack2048.ToArray();
                int ii = 0;
                int s = stack2048.Count - 1;
                while (s >= 0)
                {
                    this.Board.Tiles[ii, j] = processedrow[s];
                    s--;
                    ii++;
                }
            }
        }
    }
}
