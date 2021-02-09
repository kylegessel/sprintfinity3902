using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public IEntity Sprite { get; set; }
        Player PlayerCharacter;

        public FacingUpState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkUpSprite(PlayerCharacter.Texture, PlayerCharacter.Position);
            
        }

        public void Move()
        {
            Sprite.Y = Sprite.Y - 5;
        }
    }
}
