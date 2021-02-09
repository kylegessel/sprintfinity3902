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
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingLeft)
            {
                PlayerCharacter.setState(PlayerCharacter.facingLeft);
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
