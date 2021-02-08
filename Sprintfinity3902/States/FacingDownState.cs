using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingDownState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkDownSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            Sprite.GetAnimation();
        }

        public void Move()
        {
            Sprite.CurrentPositionY = Sprite.CurrentPositionY + 5;
            PlayerCharacter.setCurrentPositionY(Sprite.CurrentPositionY);
        }

        public void StopMoving()
        {
            Sprite = new LinkDownIdleSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
        }

    }
}
