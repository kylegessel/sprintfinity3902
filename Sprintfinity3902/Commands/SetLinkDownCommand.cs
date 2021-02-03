using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class SetLinkDownCommand : ICommand
    {
        Player PlayerCharacter;

        public SetLinkDownCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.currentState != PlayerCharacter.facingDown)
            {
                PlayerCharacter.setState(PlayerCharacter.facingDown);
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
