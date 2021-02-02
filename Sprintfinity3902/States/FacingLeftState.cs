using Ardrey.Sprint0.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.States
{
    public class FacingLeftState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingLeftState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkLeftSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            Sprite.GetAnimation();
        }

        public void Move()
        {
            Sprite.CurrentPositionX = Sprite.CurrentPositionX - 5;
            PlayerCharacter.setCurrentPositionX(Sprite.CurrentPositionX);
        }
    }
}
