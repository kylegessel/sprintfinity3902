using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingDownIdleState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingDownIdleState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkDownIdleSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
        }

        public void Move()
        {
            //Won't move
        }

    }
}