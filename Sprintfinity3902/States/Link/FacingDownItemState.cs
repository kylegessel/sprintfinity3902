using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class FacingDownItemState : IState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        private Boolean itemExecuted = false;
        public FacingDownItemState(Player currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownItemSprite();
            Sprite.Animation.IsPlaying = false;
        }


        public void Move()
        {
            //NULL
        }

        public void Attack()
        {

            //NULL
            
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
                PlayerCharacter.SetState(PlayerCharacter.facingDown);
                itemExecuted = false;
            }
        }

    }
}
