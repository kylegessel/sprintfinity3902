using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.Collision
{
    public class CollisionDetector {


        Game1 gameInstance;
        Player link;



        /* Singleton instance */

        private static CollisionDetector instance;
        public static CollisionDetector Instance {
            get {
                if (instance == null) {
                    instance = new CollisionDetector();
                }
                return instance;
            }
        }

        //public CollisionDetector() {
        //Reset();
        // }
        public void setup(Game1 game)
        {
            gameInstance = game;
            link = (Player)game.playerCharacter;
        }
        
        /* This method updates the InputKeyboard singleton
         * to remove clutter from game class. Additionally,
         * the InputKeyboard will call this.CallCommands and 
         * this.CallHandlers if it needs to.
         */
        public void CheckCollision( List<IEntity> entities) {

            Rectangle linkrect = link.GetBoundingRect();

            foreach (AbstractEntity entity in entities)
            {
                if (entity.IsCollidable() && entity.GetBoundingRect().Intersects(linkrect))
                {
                    ILink damagedLink = new DamagedLink(link, gameInstance);
                    gameInstance.playerCharacter = damagedLink;
                }
            }
        }

    }
}
