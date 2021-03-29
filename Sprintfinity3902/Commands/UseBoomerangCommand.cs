using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{


    public class UseBoomerangCommand : ICommand
    {
        Player PlayerCharacter;
        BoomerangItem Boomerang;

        public UseBoomerangCommand(Player player, BoomerangItem boomerang)
        {
            PlayerCharacter = player;
            Boomerang = boomerang;
        }

        public void Execute()
        {
            //Eventually this should all live within player, this should become a call to use item.
            if (!Boomerang.getItemUse() && PlayerCharacter.itemcount[IItem.ITEMS.BOOMERANG] > 0)
            {
                PlayerCharacter.UseItem();
                Boomerang.UseItem(PlayerCharacter);
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Arrow_Boomerang).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            }
        }
    }
}

