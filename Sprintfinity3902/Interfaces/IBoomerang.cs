using Sprintfinity3902.Entities;
using System;

namespace Sprintfinity3902.Interfaces
{
    public interface IBoomerang : IItem, IProjectile
    {
        void FireItem();
        Boolean getItemUse();
        void doneUsing();
        void MoveItem();
        void ResetItem();
        void Return();
        void UseItem(ILink player);
        void UseItem(GoriyaEnemy goriya); //Probably want this to be an IEnemy
        public AbstractEntity.Direction FireDirection { get; set; }

    }
}
