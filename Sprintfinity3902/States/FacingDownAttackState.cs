using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingDownAttackState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        private Boolean AttackExecuted = false;
        public FacingDownAttackState(ILink currentPlayer)
        {
            //PlayerCharacter = playerCharacter;
            //get game time 
            // Sprite = new LinkDownAttackSprite(PlayerCharacter.PlayerTexture, PlayerCharacter.StartingLocation);
            //Sprite.GetAnimation();
            Player = (Player)currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownAttackSprite();
            Sprite.Animation.IsPlaying = false;

            //compare game time 

            //set to prev state
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

        public void Update()
        {
            if (!Sprite.Animation.IsPlaying && AttackExecuted)
            {
                Player.SetState(Player.facingDown);
                AttackExecuted = false;
            }
        }

    }
}
