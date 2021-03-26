using System;
using System.Collections.Generic;
using System.Text;

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

        /*These methods are only used when link is not invinsible (damaged state)*/
        void MoveLink();
        void StopMoving();
        void TakeDamage();
        void BounceOfEnemy(ICollision.CollisionSide Side);
    }
}
