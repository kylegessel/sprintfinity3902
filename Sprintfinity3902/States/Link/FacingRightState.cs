using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingRightState : IPlayerState
    {
        public IPlayer PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingRightState(IPlayer currentPlayer)
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
            /*MAGIC NUMBERS REFACTOR
             the line  here used to be:

            PlayerCharacter.X = PlayerCharacter.X + 1 * Global.Var.SCALE;

            but now is below because this simplifies with pemdas.
            If OP wanted to subtract one before multiplying use braces and 
            optionally add Magic number for 1
             */
            PlayerCharacter.X = PlayerCharacter.X + Global.Var.SCALE;
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
