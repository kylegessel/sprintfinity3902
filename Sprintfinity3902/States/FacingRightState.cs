using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IPlayerState
    {
        public IEntity Sprite { get; set; }
        Player PlayerCharacter;

        public FacingRightState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkRightSprite(PlayerCharacter.Texture, PlayerCharacter.Position);
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Sprite.X = Sprite.X + 5;
        }

    }
}
