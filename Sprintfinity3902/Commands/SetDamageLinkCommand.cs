using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    class SetDamageLinkCommand : ICommand
    {
        IPlayer decoratedLink;
        ILink damagedLink;
        Game1 game;

        public SetDamageLinkCommand(Game1 game)
        {
            this.game = game;
            decoratedLink = game.playerCharacter;
        }

        public void Execute()
        {
            damagedLink = new DamagedLink(decoratedLink, game);
            game.link = damagedLink;
        }
    }
}
