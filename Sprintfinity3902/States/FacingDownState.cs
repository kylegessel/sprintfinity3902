using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownState(ILink currentPlayer)
        {
            Player = (Player)currentPlayer;
            // Some type of if-else statement to get the damaged version?
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownSprite();
            
            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.Y = Player.Y + 5;
        }

        public void Attack()
        {
            Player.SetState(Player.facingDownAttack);
        }
        
        public void Update()
        {

        }

    }
}
