using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IPlayerState
    {
        public Player Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingRightState(ILink currentPlayer)
        {
            Player = (Player)currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.X = Player.X + 5;
        }

        public void Attack()
        {
            Player.SetState(Player.facingRightAttack);
        }

        public void Update()
        {

        }

    }
}
