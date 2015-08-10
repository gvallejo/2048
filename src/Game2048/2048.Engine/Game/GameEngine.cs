using _2048.Engine.AI;
using _2048.Engine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public class GameEngine: IGameEngine
    {
        protected IBoard _board = null;
        public IMoveProcessor MoveProcessor { get; private set; }
        public IAIModule AIModule { get; private set; }
        public IGameInput Input { get; private set; }
        public IGameOutput Output { get; private set; }

        public GameEngine(IBoard board, IMoveProcessor moveProcessor, IAIModule aiModule, IGameInput input, IGameOutput output)
        {
            _board = board;
            this.MoveProcessor = moveProcessor;
            this.MoveProcessor.Board = _board;
            this.AIModule = aiModule;
            this.Input = input;
            this.Output = output;

            this.Input.OnMoveReceived += Input_OnMoveReceived;
        }

        void Input_OnMoveReceived(object sender, MoveEventArgs args)
        {
            MoveDirection move = (MoveDirection)sender;
            ProcessMove(move);
        }

        public event GameEventHandler OnGameOver;
        public event GameEventHandler OnNewGame;

        public virtual void ProcessMove(MoveDirection move)
        {

            SiAuto.Main.EnterMethod(this, "ProcessMove");
            try
            {
                /*--------- Your code goes here-------*/
                
                this.MoveProcessor.ProcessMove(move);

                //TODO:  IA module must generate random tiles, each of which can be either 
                //2 (90% probability) or 4 (10% probability). 
                if (this.AIModule != null)
                {
                    this.AIModule.GenerateRandomTile(ref _board);
                    this.AIModule.GenerateRandomTile(ref _board);
                }

                this.Output.SetBoard(_board);

                if (this.AIModule != null)
                {
                    if (this.AIModule.IsGameOver(_board))
                        if (this.OnGameOver != null)
                            this.OnGameOver(null, new EventArgs());
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
                SiAuto.Main.LeaveMethod(this, "ProcessMove");
            }

        }

        public virtual void NewGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //clear the tiles in the row
                    _board.Tiles[i, j] = 0;
                }
            }

            //TODO:  IA module must generate random tiles, each of which can be either 
            //2 (90% probability) or 4 (10% probability). 
            if (this.AIModule != null)
            {
                this.AIModule.GenerateRandomTile(ref _board);
                this.AIModule.GenerateRandomTile(ref _board);
            }

            this.Output.SetBoard(_board);

            if (this.OnNewGame != null)
                this.OnNewGame(null, new EventArgs());
        }


        public virtual void SetTile(int r, int c, int value)
        {
            _board.Tiles[r, c] = value;
            this.Output.SetBoard(_board);
        }




       
    }
}
