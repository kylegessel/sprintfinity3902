using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class GohmaBoss : AbstractEntity, IEnemy
    {
        public GohmaBoss(Vector2 pos)
        {
            Sprite = EnemySpriteFactory.Instance.CreateGohmaClosedEye();
            Position = pos;
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            int i = 1;
            if (proj.GetType().Equals(typeof(ArrowItem)))
            {
                i = 0;
            }
            return i;
        }
    }
}
