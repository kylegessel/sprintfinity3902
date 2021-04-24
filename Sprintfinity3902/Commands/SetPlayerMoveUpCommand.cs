using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveUpCommand: ICommand
    {
        IPlayer PlayerCharacter;

        public SetPlayerMoveUpCommand(IPlayer player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.openToInput)
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
}
