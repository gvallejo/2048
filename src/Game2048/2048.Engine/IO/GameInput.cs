﻿using _2048.Engine.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.IO
{
    public class GameInput: IGameInput
    {
        public GameInput()
        {

        }

        public event MoveEventHandler OnMoveReceived;

        public void Move(MoveDirection direction)
        {
            if(this.OnMoveReceived != null)
            {
                this.OnMoveReceived(direction, new MoveEventArgs());
            }
        }
    }
}
