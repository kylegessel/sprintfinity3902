using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetLinkDownAttackCommand : ICommand {
        Player PlayerCharacter;

        public SetLinkDownAttackCommand(Player player) {
            PlayerCharacter = player;
        }

        public void Execute() {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingDownAttack) {
                PlayerCharacter.SetState(PlayerCharacter.facingDownAttack);
                PlayerCharacter.facingDownAttack.Sprite.Animation.Play();
            } else {
                PlayerCharacter.Move();
            }

        }
    }
}