using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveDownCommand : ICommand
    {
        IPlayer PlayerCharacter;

        public SetPlayerMoveDownCommand(IPlayer player)
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
