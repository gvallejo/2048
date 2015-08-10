using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.IO
{
    public delegate void BoardEventHandler(object sender, EventArgs args); 
    public interface IGameOutput
    {
        event BoardEventHandler OnBoardChange;
        IBoard GetBoard();
        void SetBoard(IBoard board);
    }
}
