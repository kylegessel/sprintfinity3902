using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingDownAttackState : IPlayerState
    {
        public ILink Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownAttackState(ILink currentPlayer)
        {
            Player = currentPlayer;
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownAttackSprite();
            if(Sprite.Animation.IsPlaying == false)
            {
                //Player.SetState(Player.facingDown);
            }
        }


        public void Move()
        {

            //Sprite.CurrentPositionY = Sprite.CurrentPositionY + 5;
            //PlayerCharacter.setCurrentPositionY(Sprite.CurrentPositionY);
        }

    }
}
