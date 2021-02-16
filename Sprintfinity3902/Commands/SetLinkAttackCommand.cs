using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetLinkAttackCommand: ICommand
    {
        Player PlayerCharacter;
        MovingSwordItem MovingSword;

        public SetLinkAttackCommand(Player player, MovingSwordItem movingSword)
        {
            PlayerCharacter = player;
            MovingSword = movingSword;
        }

        public void Execute()
        {
            //if (PlayerCharacter.currentState != PlayerCharacter.facingDownAttack)
            //{
            //    PlayerCharacter.setState(PlayerCharacter.facingDownAttack);
            //}
            //else
            PlayerCharacter.Attack();
            if (!MovingSword.getItemUse())
            {
                PlayerCharacter.Attack();
                MovingSword.UseItem(PlayerCharacter);
            }
        }
    }
}
