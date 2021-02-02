using Ardrey.Sprint0;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class SetLinkUpCommand : ICommand
    {
        Player PlayerCharacter;

        public SetLinkUpCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.currentState != PlayerCharacter.getFacingUpState())
            {
                PlayerCharacter.setState(PlayerCharacter.getFacingUpState());
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
