using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveDownCommand : ICommand
    {
        Player PlayerCharacter;

        public SetPlayerMoveDownCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingDown)
            {
                PlayerCharacter.SetState(PlayerCharacter.facingDown);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
