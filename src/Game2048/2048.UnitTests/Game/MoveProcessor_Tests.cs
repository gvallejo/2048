using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2048.Engine.Game;
using NBehave.Spec.MSTest;
using Moq;

namespace _2048.UnitTests.Game
{
    [TestClass]
    public class When_working_with_MOVE_PROCESSOR_Set_this_Up : Specification
    {

        protected int[,] _tiles = null;
        protected Mock<IBoard> _board = null;
        protected IMoveProcessor _moveProcessor = null;
        protected int[,] _expectedTiles = null;
        protected MoveDirection _direction;
       

        protected override void Establish_context()
        {
            base.Establish_context();
                        
        }

        protected override void Because_of()
        {
           

        }
       
        protected bool CompareToExpected(int[,] tiles)
        {            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i, j] != _expectedTiles[i, j])
                        return false;
                }
            }
            return true;
        }

    }

    [TestClass]
    public class When_working_with_MOVE_PROCESSOR_AND_Process_Move_To_LEFT : When_working_with_MOVE_PROCESSOR_Set_this_Up
    {
        protected override void Establish_context()
        {
            base.Establish_context();

            _tiles = new int[4, 4]
            {
                {2,  2,  0,  4},
                {4,  2,  4,  4},
                {2,  2,  0,  2},
                {0,  0,  0,  0}
        
            };

            _expectedTiles = new int[4, 4]
            {
                {4,  4,  0,  0},
                {4,  2,  8,  0},
                {4,  2,  0,  0},
                {0,  0,  0,  0}
        
            };

            _board = new Mock<IBoard>();
            _board.Setup(x => x.Tiles).Returns(_tiles);
            _moveProcessor = new MoveProcessor(_board.Object);
        }
       
        protected override void Because_of()
        {
            base.Because_of();
           
            _direction = MoveDirection.LEFT;
            _moveProcessor.ProcessMove(_direction);
          
        }

        [TestMethod]
        public void then_Board_tiles_must_be_equal_than_expected()
        {
            
            CompareToExpected(_moveProcessor.Board.Tiles).ShouldBeTrue();
            
        }
    }

    [TestClass]
    public class When_working_with_MOVE_PROCESSOR_AND_Process_Move_To_RIGHT : When_working_with_MOVE_PROCESSOR_Set_this_Up
    {
        protected override void Establish_context()
        {
            base.Establish_context();

            _tiles = new int[4, 4]
            {
                {4,  2,  0,  2},
                {4,  2,  4,  4},
                {2,  2,  0,  2},
                {0,  0,  0,  0}
        
            };

            _expectedTiles = new int[4, 4]
            {
                {0,  0,  4,  4},
                {0,  4,  2,  8},
                {0,  0,  2,  4},
                {0,  0,  0,  0}
        
            };

            _board = new Mock<IBoard>();
            _board.Setup(x => x.Tiles).Returns(_tiles);
            _moveProcessor = new MoveProcessor(_board.Object);
        }

        protected override void Because_of()
        {
            base.Because_of();

            _direction = MoveDirection.RIGHT;
            _moveProcessor.ProcessMove(_direction);

        }

        [TestMethod]
        public void then_Board_tiles_must_be_equal_than_expected()
        {

            CompareToExpected(_moveProcessor.Board.Tiles).ShouldBeTrue();

        }
    }


    [TestClass]
    public class When_working_with_MOVE_PROCESSOR_AND_Process_Move_DOWN : When_working_with_MOVE_PROCESSOR_Set_this_Up
    {
        protected override void Establish_context()
        {
            base.Establish_context();

            _tiles = new int[4, 4]
            {
                {2,  2,  0,  2},
                {4,  2,  4,  4},
                {0,  0,  0,  0},
                {0,  0,  0,  0}
        
            };

            _expectedTiles = new int[4, 4]
            {
                {0,  0,  0,  0},
                {0,  0,  0,  0},
                {2,  0,  0,  2},
                {4,  4,  4,  4}
        
            };

            _board = new Mock<IBoard>();
            _board.Setup(x => x.Tiles).Returns(_tiles);
            _moveProcessor = new MoveProcessor(_board.Object);
        }

        protected override void Because_of()
        {
            base.Because_of();

            _direction = MoveDirection.DOWN;
            _moveProcessor.ProcessMove(_direction);

        }

        [TestMethod]
        public void then_Board_tiles_must_be_equal_than_expected()
        {

            CompareToExpected(_moveProcessor.Board.Tiles).ShouldBeTrue();

        }
    }

    [TestClass]
    public class When_working_with_MOVE_PROCESSOR_AND_Process_Move_UP : When_working_with_MOVE_PROCESSOR_Set_this_Up
    {
        protected override void Establish_context()
        {
            base.Establish_context();

            _tiles = new int[4, 4]
            {
                {2,  2,  0,  2},
                {4,  2,  4,  4},
                {0,  0,  0,  0},
                {0,  0,  0,  0}
        
            };

            _expectedTiles = new int[4, 4]
            {
                {2,  4,  4,  2},
                {4,  0,  0,  4},
                {0,  0,  0,  0},
                {0,  0,  0,  0}
        
            };

            _board = new Mock<IBoard>();
            _board.Setup(x => x.Tiles).Returns(_tiles);
            _moveProcessor = new MoveProcessor(_board.Object);
        }

        protected override void Because_of()
        {
            base.Because_of();

            _direction = MoveDirection.UP;
            _moveProcessor.ProcessMove(_direction);

        }

        [TestMethod]
        public void then_Board_tiles_must_be_equal_than_expected()
        {

            CompareToExpected(_moveProcessor.Board.Tiles).ShouldBeTrue();

        }
    }

}
