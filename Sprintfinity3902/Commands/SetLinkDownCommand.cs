using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.Commands
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
            if (PlayerCharacter.currentState != PlayerCharacter.getFacingDownState())
            {
                PlayerCharacter.setState(PlayerCharacter.getFacingDownState());
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
