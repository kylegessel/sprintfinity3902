using Sprintfinity3902.Interfaces;

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
            if (PlayerCharacter.openToInput)
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
}
