using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{


    public class UseBowCommand : ICommand
    {
        Player PlayerCharacter;
        ArrowItem Arrow;

        public UseBowCommand(Player player, ArrowItem arrow)
        {
            PlayerCharacter = player;
            Arrow = arrow;
        }

        public void Execute()
        {
            //Eventually this should all live within player, this should become a call to use item.
            if (!Arrow.getItemUse() && PlayerCharacter.itemcount[IItem.ITEMS.BOW] > 0)
            {
                PlayerCharacter.UseItem();
                Arrow.UseItem(PlayerCharacter);
            }
        }
    }
}

