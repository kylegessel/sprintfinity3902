using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IItem
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
            TRIFORCE
        };

        public IPickup GetPickup();
    }
}
