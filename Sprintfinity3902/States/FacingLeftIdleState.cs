using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingLeftIdleState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingLeftIdleState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkLeftIdleSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
        }

        public void Move()
        {
            //Won't move
        }

    }
}