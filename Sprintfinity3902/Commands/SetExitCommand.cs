using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
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

