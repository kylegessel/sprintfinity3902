using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingRightState(Player currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            PlayerCharacter.X = PlayerCharacter.X + 5;
        }

        public void Attack()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingRightAttack);
            PlayerCharacter.Attack();
        }

        public void UseItem()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingRightItem);
            PlayerCharacter.UseItem();
        }
        
        public void Update()
        {

        }

    }
}
