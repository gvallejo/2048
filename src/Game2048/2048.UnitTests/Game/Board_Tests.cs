using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2048.Engine.Game;
using NBehave.Spec.MSTest;

namespace _2048.UnitTests.Game
{
    [TestClass]
    public class When_working_with_BOARD_Set_this_Up : Specification
    {

        protected int[,] _tiles = null;
        protected IBoard _board = null;
        protected bool _result_rows_accessor;
        protected bool _result_cols_accessor;

        protected override void Establish_context()
        {
            base.Establish_context();
            _tiles = new int[4, 4]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
        
            };
           
           
        }       

        protected override void Because_of()
        {
           

        }

        protected bool VerifyRowsAccessor()
        {
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(_board.Tiles[i,j] != _board.RowsLeftToRight[i][j])
                    {
                        return false;                       
                    }
                }
            }
            return result;
        }

        protected bool VerifyColsAccessor()
        {
            bool result = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_board.Tiles[i, j] != _board.ColsTopDown[j][i])
                    {
                        return false;
                    }
                }
            }
            return result;
        }

    }

    [TestClass]
    public class When_working_with_BOARD_AND_Setting_Board_using_Default_ctor_AND_DisplayingBoard_using_ROWS_COLS_Accessors : When_working_with_BOARD_Set_this_Up
    {
        //IGameEngine _gameEngine = null;
        //IGame _game = null;
        
       
        //ICommand _move = 
      
        protected override void Because_of()
        {           
            base.Because_of();

            _board = new Board();
            _board.SetTiles(_tiles);
            _result_rows_accessor = VerifyRowsAccessor();
            _result_cols_accessor = VerifyColsAccessor();

            //_game = _gameEngine.NewGame();
            //_game.Start();
            //_board = _game.Output.GetBoard();
            //_game.Input.ReadCommand(IMove);
            //_game.OnBoardChange
            //_game.OnGameOver;
            //_game.Reset();
            //_game.Input.CanInputCommand
            //_board.Rows
        }

        [TestMethod]
        public void then_a_TRUE_result_must_obtained()
        {
            _result_cols_accessor.ShouldBeTrue();
            _result_rows_accessor.ShouldBeTrue();
        }
    }

    [TestClass]
    public class When_working_with_BOARD_AND_Setting_Board_using_ctor1_AND_DisplayingBoard_using_ROWS_COLS_Accessors : When_working_with_BOARD_Set_this_Up
    {
       
        protected override void Because_of()
        {
            base.Because_of();

            _board = new Board(_tiles);

            _result_rows_accessor = VerifyRowsAccessor();
            _result_cols_accessor = VerifyColsAccessor();

        }

        [TestMethod]
        public void then_a_TRUE_result_must_obtained()
        {
            _result_cols_accessor.ShouldBeTrue();
            _result_rows_accessor.ShouldBeTrue();
        }
    }
}
