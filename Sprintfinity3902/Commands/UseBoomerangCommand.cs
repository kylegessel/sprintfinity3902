using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Link;
using Microsoft.Xna.Framework;

namespace Sprintfinity3902.Commands
{


    public class UseBoomerangCommand : ICommand
    {
        Player PlayerCharacter;
        BoomerangItem Boomerang;

        public UseBoomerangCommand(Player player, BoomerangItem boomerang)
        {
            PlayerCharacter = player;
            Boomerang = boomerang;
        }

        public void Execute()
        {
            if (!Boomerang.getItemUse())
            {
                Boomerang.UseItem(PlayerCharacter);
            }
        }
    }
}

