using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public Player PlayerCharacter { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownState(Player currentPlayer)
        {
            PlayerCharacter = currentPlayer;
            // Some type of if-else statement to get the damaged version?
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownSprite();
            
            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            PlayerCharacter.Y = PlayerCharacter.Y + 5;
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
