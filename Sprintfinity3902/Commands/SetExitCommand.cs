using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0
{
    public class SetExitCommand : ICommand
    {
        private Game1 myGame;

        public SetExitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}

