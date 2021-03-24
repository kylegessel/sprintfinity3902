using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;

namespace Sprintfinity3902.Commands
{


    public class UseBombCommand : ICommand
    {
        /*Player PlayerCharacter;*/
        ILink link;
        BombItem Bomb;

        public UseBombCommand(ILink player, BombItem bomb)
        {
            /*PlayerCharacter = player;*/
            link = player;
            Bomb = bomb;
        }

        public void Execute()
        {
            //Eventually this should all live within player, this should become a call to use item.
            if (!Bomb.getItemUse())
            {
                link.UseItem();
                Bomb.UseItem(link);
                /*
                PlayerCharacter.UseItem();
                Bomb.UseItem(PlayerCharacter);
                //PlayerCharacter.UseItem();
                */
            }
        }
    }
}

