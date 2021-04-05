using System.Collections.Generic;


namespace Sprintfinity3902.Interfaces
{
    public interface IPlayer : ILink
    {
        enum SelectableWeapons
        {
            BOMB,
            BOOMERANG,
            BOW,
            MAP
        }
        IPlayerState CurrentState { get; set; }
        IPlayerState facingDown { get; set; }
        IPlayerState facingLeft { get; set; }
        IPlayerState facingRight { get; set; }
        IPlayerState facingUp { get; set; }
        IPlayerState facingDownAttack { get; set; }
        IPlayerState facingLeftAttack { get; set; }
        IPlayerState facingRightAttack { get; set; }
        IPlayerState facingUpAttack { get; set; }
        IPlayerState facingDownItem { get; set; }
        IPlayerState facingLeftItem { get; set; }
        IPlayerState facingRightItem { get; set; }
        IPlayerState facingUpItem { get; set; }
        bool heartChanged { get; set; }
        bool itemPickedUp { get; set; }
        int MaxHealth { get; set; }
        int LinkHealth { get; set; }
        Dictionary<IItem.ITEMS, int> itemcount { get; set; }

        SelectableWeapons SelectedWeapon { get; set; }


        /*These methods are only used when link is not invinsible (damaged state)*/
        void MoveLink();
        void StopMoving();
        void TakeDamage();
        void BounceOfEnemy(ICollision.CollisionSide Side);
        void Initialize();
        void TogglePlayerVisible();
        void ToggleCollidable();
        void ChangeRooms();
    }
}
