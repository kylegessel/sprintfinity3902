using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class FacingRightAttackState : IPlayerState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        private Boolean AttackExecuted = false;
        public FacingRightAttackState(Player currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkRightAttackSprite();
            Sprite.Animation.IsPlaying = false;

        
        }


        public void Move()
        {
            //NULL
        }

        public void Attack()
        {
            if (!Sprite.Animation.IsPlaying)
            {
                AttackExecuted = true;
                Sprite.Animation.PlayOnce();
            }
            
            
        }

        public void UseItem()
        {
            //NULL
        }

        public void Update()
        {
            if (!Sprite.Animation.IsPlaying && AttackExecuted)
            {
                PlayerCharacter.SetState(PlayerCharacter.facingRight);
                AttackExecuted = false;
            }
        }

    }
}
