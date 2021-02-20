using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveLeftCommand: ICommand
    {
        Player PlayerCharacter;

        public SetPlayerMoveLeftCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingLeft)
            {
                PlayerCharacter.SetState(PlayerCharacter.facingLeft);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
