using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.States
{
    public class FacingLeftAttackState : IPlayerState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        private Boolean AttackExecuted = false;
        public FacingLeftAttackState(Player currentPlayer)
        {

            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkLeftAttackSprite();
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
                PlayerCharacter.SetState(PlayerCharacter.facingLeft);
                AttackExecuted = false;
            }
        }

    }
}
