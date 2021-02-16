using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public Player player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownState(Player currentPlayer)
        {
            player = currentPlayer;
            // Some type of if-else statement to get the damaged version?
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownSprite();
            
            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            player.Y = player.Y + 5;
        }

        public void Attack()
        {
            player.SetState(player.facingDownAttack);
            player.Attack();
        }

        public void UseItem()
        {
            player.SetState(player.facingDownItem);
            player.UseItem();
        }
        
        public void Update()
        {

        }

    }
}
