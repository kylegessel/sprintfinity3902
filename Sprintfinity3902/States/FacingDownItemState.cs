using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities;
using System;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingDownItemState : IPlayerState
    {
        public Player Link { get; set; }
        public ISprite Sprite { get; set; }

        private Boolean itemExecuted = false;
        public FacingDownItemState(Player currentPlayer)
        {
            Link = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownAttackSprite();
            Sprite.Animation.IsPlaying = false;
        }


        public void Move()
        {
            //NULL
        }

        public void Attack()
        {

            
            
        }

        public void UseItem()
        {
            if (!Sprite.Animation.IsPlaying)
            {
                itemExecuted = true;
                Sprite.Animation.PlayOnce();
            }
        }

        public void Update()
        {
            if (!Sprite.Animation.IsPlaying && itemExecuted)
            {
                Link.SetState(Link.facingDown);
                itemExecuted = false;
            }
        }

    }
}
