using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Link;
using Microsoft.Xna.Framework;

namespace Sprintfinity3902.Commands
{


    public class UseBombCommand : ICommand
    {
        Player PlayerCharacter;
        BombItem Bomb;

        public UseBombCommand(Player player, BombItem bomb)
        {
            PlayerCharacter = player;
            Bomb = bomb;
        }

        public void Execute()
        {
            if (!Bomb.getItemUse())
            {
                Bomb.UseItem(PlayerCharacter);
            }
        }
    }
}

