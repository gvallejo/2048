using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2048.Engine.Game;
using NBehave.Spec.MSTest;
using _2048.Engine.IO;
using Moq;

namespace _2048.UnitTests.IO
{
    [TestClass]
    public class When_working_with_INPUT_Set_this_Up : Specification
    {
        protected IGameInput _gameInput = null;
        protected MoveDirection _cmd;
        protected MoveDirection _result;

        protected override void Establish_context()
        {
            base.Establish_context();
            _cmd = MoveDirection.LEFT;
            _gameInput = new GameInput();
            
        }

        protected override void Because_of()
        {
            _gameInput.Move(_cmd);            
        }

        

    }

[TestClass]
    public class When_working_with_INPUT_AND_Subscribing_To_OnCommandReceived : When_working_with_INPUT_Set_this_Up
    {
        
        protected override void Establish_context()
        {
            base.Establish_context();
            _gameInput.OnMoveReceived += _gameInput_OnCommandReceived;
        }

        protected override void Because_of()
        {
            base.Because_of();
        }

        void _gameInput_OnCommandReceived(object sender, MoveEventArgs args)
        {
            _result = (MoveDirection)sender;

        }

        [TestMethod]
        public void then_the_received_MOVE_via_event_ShouldBeTheSameAs_the_MOVE_set_using_Move()
        {
            _result.ShouldEqual<MoveDirection>(_cmd);
        }

    }
}
