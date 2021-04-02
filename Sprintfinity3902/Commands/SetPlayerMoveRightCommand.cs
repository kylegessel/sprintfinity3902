using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveRightCommand: ICommand
    {
        IPlayer PlayerCharacter;

        public SetPlayerMoveRightCommand(IPlayer player)
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
