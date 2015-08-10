using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.IO
{
    public class GameOutput: IGameOutput
    {
        private IBoard _board;
        public event BoardEventHandler OnBoardChange;

        public IBoard GetBoard()
        {
            return this._board;
        }

        public void SetBoard(IBoard board)
        {

            SiAuto.Main.EnterMethod(this, "SetBoard");
            try
            {
                /*--------- Your code goes here-------*/
                this._board = board;
                if (this.OnBoardChange != null)
                    this.OnBoardChange(board.Tiles, new EventArgs());
                /*------------------------------------*/
            }
            catch (Exception ex)
            {
                SiAuto.Main.LogException(ex);
                throw ex;
            }
            finally
            {
                SiAuto.Main.LeaveMethod(this, "SetBoard");
            }

        }
    }
}
