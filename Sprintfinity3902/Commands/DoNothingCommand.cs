using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0
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

