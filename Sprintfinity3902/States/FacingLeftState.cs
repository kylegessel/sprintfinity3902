using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingLeftState : IPlayerState
    {
        public ILink Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingLeftState(ILink currentPlayer)
        {
            Player = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.X = Player.X - 5;
        }

    }
}
