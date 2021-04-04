using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface ILink : IEntity
    {

        void SetState(IPlayerState state);
        void RemoveDecorator();
        void UseItem(IItem.ITEMS item);
        public void UseItem();
        void Pickup(IItem item);
        void DeathSpin(bool end);
    }
}

