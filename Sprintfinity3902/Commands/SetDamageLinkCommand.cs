using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    class SetDamageLinkCommand : ICommand
    {
        Player decoratedLink;
        ILink damagedLink;
        Game1 game;

        public SetDamageLinkCommand(Game1 game)
        {
            this.game = game;
            decoratedLink = (Player)game.playerCharacter;
        }

        public void Execute()
        {
            //game.playerCharacter.TakeDamage();
            damagedLink = new DamagedLink(decoratedLink, game);
            game.playerCharacter = damagedLink;
        }
    }
}
