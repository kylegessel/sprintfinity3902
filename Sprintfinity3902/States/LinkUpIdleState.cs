using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingUpIdleState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingUpIdleState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkUpIdleSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
        }

        public void Move()
        {
            //Won't move
        }

    }
}