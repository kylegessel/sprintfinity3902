using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetLinkAttackCommand: ICommand
    {
        Player PlayerCharacter;

        public SetLinkAttackCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            //if (PlayerCharacter.currentState != PlayerCharacter.facingDownAttack)
            //{
            //    PlayerCharacter.setState(PlayerCharacter.facingDownAttack);
            //}
            //else
            PlayerCharacter.Attack();
        }
    }
}
