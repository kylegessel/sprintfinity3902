using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
{
    class SetDamageLinkCommand : ICommand
    {
        AbstractEntity PlayerCharacter;
        

        public SetDamageLinkCommand(Player player, Game1 game)
        {
            PlayerCharacter = player;
            PlayerCharacter = new DamagedLink(player, game);
            
        }

        public void Execute()
        {
            
        }
    }
}
