using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveUpCommand: ICommand
    {
        Player PlayerCharacter;

        public SetPlayerMoveUpCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingUp)
            {
                PlayerCharacter.SetState(PlayerCharacter.facingUp);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
