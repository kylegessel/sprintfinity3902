using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingUpState : IPlayerState
    {
        public IPlayer PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingUpState(IPlayer currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkUpSprite();
            Sprite.Animation.IsPlaying = false;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            /*MAGIC NUMBERS REFACTOR
             the line  here used to be:

            PlayerCharacter.Y = PlayerCharacter.Y - 1 * Global.Var.SCALE;

            but now is below because this simplifies with pemdas.
            If OP wanted to subtract one before multiplying use braces and 
            optionally add Magic number for 1
             */
            PlayerCharacter.Y = PlayerCharacter.Y - Global.Var.SCALE;
        }

        public void Attack()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingUpAttack);
            PlayerCharacter.Attack();
        }

        public void UseItem()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingUpItem);
            PlayerCharacter.UseItem();
        }

        public void Update()
        {

        }
    }
}
