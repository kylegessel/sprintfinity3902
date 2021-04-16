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
            HEART,
            HEARTCONTAINER,
            KEY,
            MAP,
            SWORD,
            RUPEE,
            TRIFORCE,
            ATTACKPWRUP,
            DFENSEPWRUP,
            SPEEDPWRUP
        };

        /* Returns true if win, else false */
        public bool Pickup(IPlayer link, IHud parent);
    }
}
