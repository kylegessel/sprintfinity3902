using Ardrey.Sprint0;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class SetLinkLeftCommand : ICommand
    {
        Player PlayerCharacter;

        public SetLinkLeftCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.currentState != PlayerCharacter.getFacingLeftState())
            {
                PlayerCharacter.setState(PlayerCharacter.getFacingLeftState());
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
