using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Commands
{
    public class SetLinkDownAttackCommand: ICommand
    {
        Player PlayerCharacter;

        public SetLinkDownAttackCommand(Player player)
        {
            PlayerCharacter = player;
        }

        public void Execute()
        {
            if (PlayerCharacter.CurrentState != PlayerCharacter.facingDownAttack)
            {
                PlayerCharacter.setState(PlayerCharacter.facingDownAttack);
                PlayerCharacter.facingDownAttack.Sprite.Animation.Play();
            }
            else
            {
                PlayerCharacter.Move();
            }
            
        }
    }
}
