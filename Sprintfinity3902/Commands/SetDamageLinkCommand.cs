using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    class SetDamageLinkCommand : ICommand
    {
        ILink Link;
        Game1 Game;
        Player playerCharacter;

        public SetDamageLinkCommand(Player player, Game1 game)
        {
            Link = player;
            Game = game;
            playerCharacter = player;
            
            //Link = new DamagedLink(player, game);
        }

        public void Execute()
        {
            Link.TakeDamage();
            Link = new DamagedLink(playerCharacter, Game);
        }
    }
}
