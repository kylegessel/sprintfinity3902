using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities;

namespace Sprintfinity3902.States
{
    public class FacingDownAttackState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingDownAttackState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            //get game time 
            Sprite = new LinkDownAttackSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            Sprite.GetAnimation();

            //compare game time 

            //set to prev state
        }


        public void Move()
        {
            //NULL
        }

        public void Attack()
        {
            //NULL
        }

    }
}
