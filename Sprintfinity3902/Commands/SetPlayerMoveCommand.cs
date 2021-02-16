using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveCommand: ICommand
    {
        Player PlayerCharacter;
        private IState _state;

        public SetPlayerMoveCommand(Player player, IState state)
        {
            PlayerCharacter = player;
            _state = state;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != _state)
            {
                PlayerCharacter.SetState(_state);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
