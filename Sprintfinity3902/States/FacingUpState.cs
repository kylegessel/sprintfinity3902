using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Entities;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingUpState(Player currentPlayer)
        {
            Player = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkUpSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.Y = Player.Y - 5;
        }

        public void Attack()
        {
            //Needs to be implemented
        }
    }
}
