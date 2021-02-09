using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingLeftState : IPlayerState
    {
        public IEntity Sprite { get; set; }
        Player PlayerCharacter;

        public FacingLeftState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkLeftSprite(PlayerCharacter.Texture, PlayerCharacter.Position);
            
        }

        public void Move()
        {
            Sprite.X = Sprite.X - 5;
        }
    }
}
