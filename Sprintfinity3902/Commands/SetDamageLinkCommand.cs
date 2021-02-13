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
        Player decoratedLink;
        ILink damagedLink;
        Game1 Game;
        //Player playerCharacter;

        public SetDamageLinkCommand(Game1 game)
        {
            Game = game;
            decoratedLink = (Player)Game.playerCharacter;
            
            //playerCharacter = player;
        }

        public void Execute()
        {
            Game.playerCharacter.TakeDamage();
            damagedLink = new DamagedLink(decoratedLink, Game);
            Game.playerCharacter = damagedLink;
        }
    }
}
