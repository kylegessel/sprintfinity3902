using System;
using System.Collections.Generic;
using System.Text;

namespace Ardrey.Sprint0.Commands
{
    public class SetLinkRightCommand : ICommand 
    {
        Player PlayerCharacter;

        public SetLinkRightCommand(Player player)
        {
            PlayerCharacter = player;
            
        }

        public void Execute()
        {
            if (PlayerCharacter.currentState != PlayerCharacter.getFacingRightState())
            {
                PlayerCharacter.setState(PlayerCharacter.getFacingRightState());
            }
            else
            {
                PlayerCharacter.Move();
            }
        }
    }
}
