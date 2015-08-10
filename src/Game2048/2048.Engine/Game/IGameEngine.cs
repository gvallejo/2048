using _2048.Engine.AI;
using _2048.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{

    public delegate void GameEventHandler(object sender, EventArgs args); 
    public interface IGameEngine
    {
        IMoveProcessor MoveProcessor { get;   }
        IAIModule AIModule { get;  }
        IGameInput Input { get; }
        IGameOutput Output { get;  }

        event GameEventHandler OnGameOver;
        event GameEventHandler OnNewGame;

        void NewGame();
        void ProcessMove(MoveDirection move);
        void SetTile(int r, int c, int value);        
        
    }
}
