using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public interface IMoveProcessor
    {
        IBoard Board { get; set; }
        void ProcessMove(MoveDirection move);
    }
}
