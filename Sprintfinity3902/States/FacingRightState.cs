using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingRightState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkRightSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            Sprite.GetAnimation();
        }

        public void Move()
        {
            Sprite.CurrentPositionX = Sprite.CurrentPositionX + 5;
            PlayerCharacter.setCurrentPositionX(Sprite.CurrentPositionX);
        }

        public void Attack()
        {
            //Needs to be implemented
        }

    }
}
