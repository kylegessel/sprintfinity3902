using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public Player player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingUpState(Player currentPlayer)
        {
            player = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkUpSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            player.Y = player.Y - 5;
        }

        public void Attack()
        {
            player.SetState(player.facingUpAttack);
            player.Attack();
        }

        public void UseItem()
        {
            player.SetState(player.facingUpItem);
            player.UseItem();
        }

        public void Update()
        {

        }
    }
}
