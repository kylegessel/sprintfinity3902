using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingLeftState : IState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingLeftState(Player currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            PlayerCharacter.X = PlayerCharacter.X - 5;
        }

        public void Attack()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingLeftAttack);
            PlayerCharacter.Attack();
        }

        public void UseItem()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingLeftItem);
            PlayerCharacter.UseItem();
        }
        public void Update()
        {

        }
    }
}
