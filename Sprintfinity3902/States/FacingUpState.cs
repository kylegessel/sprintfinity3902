using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingUpState(ILink currentPlayer)
        {
            Player = (Player)currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkUpSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.Y = Player.Y - 5;
        }

        public void Attack()
        {
            Player.SetState(Player.facingUpAttack);
        }

        public void Update()
        {

        }
    }
}
