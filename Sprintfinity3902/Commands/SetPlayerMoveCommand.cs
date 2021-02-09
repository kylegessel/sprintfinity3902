using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class SetPlayerMoveCommand: ICommand
    {
        Player PlayerCharacter;
        private IPlayerState _state;

        public SetPlayerMoveCommand(Player player, IPlayerState state)
        {
            PlayerCharacter = player;
            _state = state;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != _state)
            {
                PlayerCharacter.setState(_state);
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
