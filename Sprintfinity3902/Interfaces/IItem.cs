namespace Sprintfinity3902.Interfaces
{
    public interface IItem : IEntity
    {
        enum ITEMS {
            BOMB,
            BOOMERANG,
            BOW,
            CLOCK,
            COMPASS,
            FAIRY,
            FLUTE,
            HEART,
            HEARTCONTAINER,
            KEY,
            MAP,
            SWORD,
            RUPEE,
            TRIFORCE,
            ATTACKPWRUP,
        };

        public IPickup GetPickup();
    }
}
