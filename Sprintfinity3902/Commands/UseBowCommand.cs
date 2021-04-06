using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Commands
{


    public class UseBowCommand : ICommand
    {
        IPlayer PlayerCharacter;
        ArrowItem Arrow;

        public UseBowCommand(IPlayer player, ArrowItem arrow)
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
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Arrow_Boomerang).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }
    }
}

