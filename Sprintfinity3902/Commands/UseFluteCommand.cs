using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
{
    public class UseFluteCommand : ICommand
    {
        IPlayer PlayerCharacter;
        Game1 Game;

        public UseFluteCommand(IPlayer player, Game1 game)
        {
            PlayerCharacter = player;
            Game = game;
        }

        public void Execute()
        {
            if (PlayerCharacter.itemcount[IItem.ITEMS.FLUTE] > 0)
            {
                Game.SetState(Game.FLUTE);
            }
        }
    }
}

