using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{
    public class SetLinkAttackCommand: ICommand
    {
        Player PlayerCharacter;
        MovingSwordItem MovingSword;
        SwordHitboxItem Sword;

        public SetLinkAttackCommand(Player player, MovingSwordItem movingSword, SwordHitboxItem sword)
        {
            PlayerCharacter = player;
            MovingSword = movingSword;
            Sword = sword;
        }

        public void Execute()
        {
            //if (PlayerCharacter.currentState != PlayerCharacter.facingDownAttack)
            //{
            //    PlayerCharacter.setState(PlayerCharacter.facingDownAttack);
            //}
            //else
            if (!MovingSword.getItemUse())
            {
                PlayerCharacter.Attack();
                Sword.UseItem(PlayerCharacter);
                MovingSword.UseItem(PlayerCharacter);
            }
            else
            {
                PlayerCharacter.Attack();
                Sword.UseItem(PlayerCharacter);
            }
        }
    }
}
