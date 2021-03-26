using System.Collections.Generic;


namespace Sprintfinity3902.Interfaces
{
    public interface IPlayer : ILink
    {
        public IPlayerState CurrentState { get; set; }
        public IPlayerState facingDown { get; set; }
        public IPlayerState facingLeft { get; set; }
        public IPlayerState facingRight { get; set; }
        public IPlayerState facingUp { get; set; }
        public IPlayerState facingDownAttack { get; set; }
        public IPlayerState facingLeftAttack { get; set; }
        public IPlayerState facingRightAttack { get; set; }
        public IPlayerState facingUpAttack { get; set; }
        public IPlayerState facingDownItem { get; set; }
        public IPlayerState facingLeftItem { get; set; }
        public IPlayerState facingRightItem { get; set; }
        public IPlayerState facingUpItem { get; set; }
        bool heartChanged { get; set; }
        bool itemPickedUp { get; set; }
        int MAX_HEALTH { get; set; }
        int linkHealth { get; set; }
        Dictionary<IItem.ITEMS, int> itemcount { get; set; }

        /*These methods are only used when link is not invinsible (damaged state)*/
        void MoveLink();
        void StopMoving();
        void TakeDamage();
        void BounceOfEnemy(ICollision.CollisionSide Side);
    }
}
