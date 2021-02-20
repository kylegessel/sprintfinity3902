using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveRightCommand: ICommand
    {
        Player PlayerCharacter;

        public SetPlayerMoveRightCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingRight)
            {
                PlayerCharacter.SetState(PlayerCharacter.facingRight);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
