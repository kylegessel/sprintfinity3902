using Ardrey.Sprint0;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class DoNothingCommand : ICommand
    {
        private Game1 myGame;

        public DoNothingCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
        }
    }
}

