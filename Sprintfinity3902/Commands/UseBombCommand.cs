using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{


    public class UseBombCommand : ICommand
    {
        Player PlayerCharacter;
        BombItem Bomb;

        public UseBombCommand(Player player, BombItem bomb)
        {
            PlayerCharacter = player;
            Bomb = bomb;
        }

        public void Execute()
        {
            //Eventually this should all live within player, this should become a call to use item.
            if (!Bomb.getItemUse())
            {
                PlayerCharacter.UseItem();
                Bomb.UseItem(PlayerCharacter);
                Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Bomb_Drop).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
                //PlayerCharacter.UseItem();
            }
        }
    }
}

