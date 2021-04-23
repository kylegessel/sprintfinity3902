using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public IPlayer PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownState(IPlayer currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            // Some type of if-else statement to get the damaged version?
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownSprite();
            
            Sprite.Animation.IsPlaying = false;
            PlayerCharacter.openToInput = true;

        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            /*MAGIC NUMBERS REFACTOR
             the line  here used to be:

            PlayerCharacter.Y = PlayerCharacter.Y + 1 * Global.Var.SCALE;

            but now is below because this simplifies with pemdas.
            If OP wanted to subtract one before multiplying use braces and 
            optionally add Magic number for 1
             */
            PlayerCharacter.Y = PlayerCharacter.Y + Global.Var.SCALE;
        }

        public void Attack()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingDownAttack);
            PlayerCharacter.Attack();
        }

        public void UseItem()
        {
            PlayerCharacter.SetState(PlayerCharacter.facingDownItem);
            PlayerCharacter.UseItem();
        }
        
        public void Update()
        {

        }

    }
}
