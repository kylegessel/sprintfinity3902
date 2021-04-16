using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities.Items
{
    public abstract class AbstractItem : AbstractEntity,  IItem
    {
        private IItem.ITEMS id;

        public IItem.ITEMS ID {
            get { return id; }
            set { id = value; }
        }

        public virtual bool Pickup(IPlayer link)
        {
            // Not all items do something for pickup, so let child override
            return false;
        }
    }
}
