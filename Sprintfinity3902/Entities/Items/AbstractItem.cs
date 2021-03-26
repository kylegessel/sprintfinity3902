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

        virtual public IPickup GetPickup()
        {
            return new BowPickup();
        }
    }
}
