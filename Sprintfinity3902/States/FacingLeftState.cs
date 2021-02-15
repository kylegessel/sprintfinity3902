using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Entities;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingLeftState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingLeftState(ILink currentPlayer)
        {
            Player = (Player)currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.X = Player.X - 5;
        }

        public void Attack()
        {
            Player.SetState(Player.facingLeftAttack);
        }

        public void Update()
        {

        }
    }
}
