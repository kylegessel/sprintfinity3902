using System.Collections.Generic;

namespace Sprintfinity3902.Interfaces
{
    public interface IShop : IEntity
    {
        IItem Product { get; set; }
        int Cost { get; set; }
        bool Buyable { get; set; }
        List<ISprite> SpriteList { get; set; }

        void BuyItem(IPlayer link);
        //void ScrollItem(); This would be cool feature. Not necessary
    }
}
