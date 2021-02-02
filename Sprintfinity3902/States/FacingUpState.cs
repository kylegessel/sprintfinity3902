using Ardrey.Sprint0;
using Ardrey.Sprint0.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingUpState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkUpSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            Sprite.GetAnimation();

        }

        public void Move()
        {
            Sprite.CurrentPositionY = Sprite.CurrentPositionY - 5;
            PlayerCharacter.setCurrentPositionY(Sprite.CurrentPositionY);
        }
    }
}
