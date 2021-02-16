using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IPlayerState
    {
        public Player player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingRightState(Player currentPlayer)
        {
            player = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            player.X = player.X + 5;
        }

        public void Attack()
        {
            player.SetState(player.facingRightAttack);
            player.Attack();
        }

        public void UseItem()
        {
            player.SetState(player.facingRightItem);
            player.UseItem();
        }
        
        public void Update()
        {

        }

    }
}
