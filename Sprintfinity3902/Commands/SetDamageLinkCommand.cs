using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Maps;

namespace Sprintfinity3902.Commands
{
    class SetDamageLinkCommand : ICommand
    {
        Player decoratedLink;
        ILink damagedLink;
        Game1 game;
        //Player playerCharacter;

        public SetDamageLinkCommand(Game1 game)
        {
            this.game = game;
            decoratedLink = (Player)game.playerCharacter;
            
            //playerCharacter = player;
        }

        public void Execute()
        {
            game.playerCharacter.TakeDamage();
            damagedLink = new DamagedLink(decoratedLink, game);
            game.playerCharacter = damagedLink;
        }
    }
}
