using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.AI
{
    public interface IAIModule
    {
        void GenerateRandomTile(ref IBoard board);
        bool IsGameOver(IBoard board);
    }
}
