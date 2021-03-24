using Sprintfinity3902.Interfaces;
using Microsoft.Xna.Framework;
using Sprintfinity3902.Link;


namespace Sprintfinity3902.Collision
{
    public class LinkDamageHandler
    {
        private static ICollision blockCollision = new BlockCollisionHandler();
        private static ICollision enemyCollision = new EnemyCollisionHandler();
        private static ICollision.CollisionSide side;
        private static bool alreadyMoved;

        public static bool LinkDamaged(Game1 gameInstance, Player link, Rectangle linkRect, Rectangle enemyRect)
        {
            side = enemyCollision.SideOfCollision(enemyRect, linkRect);

            /*Have initial reflection so Link can't move through enemy, then continue to move him back */
            alreadyMoved = blockCollision.ReflectMovingEntity(link, side);
            ((ILink)link).BounceOfEnemy(side);

            link.TakeDamage();
            ILink damagedLink = new DamagedLink(link, gameInstance);
            gameInstance.link = damagedLink;

            return alreadyMoved;
        }
    }
}
