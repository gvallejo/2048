using _2048.Engine.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.IO
{
    public class MoveEventArgs : System.EventArgs { };
    public delegate void MoveEventHandler(object sender, MoveEventArgs args);

    public interface IGameInput
    {
      // IEnumerable<ICommand> Commands { get; set; }
       event MoveEventHandler OnMoveReceived;

       void Move(MoveDirection direction);
    }
}
