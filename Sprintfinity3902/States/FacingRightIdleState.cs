using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingRightIdleState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingRightIdleState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkRightIdleSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
        }

        public void Move()
        {
            //Won't move
        }

    }
}