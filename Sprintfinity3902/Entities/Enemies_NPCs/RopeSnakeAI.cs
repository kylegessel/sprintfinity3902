using Microsoft.Xna.Framework;
using Sprintfinity3902.Collision;
using System;

namespace Sprintfinity3902.Entities
{
    public class RopeSnakeAI
    {

        private static int ONE_HUNDRED_SIXTY = 160;
        private static int NINETY_SIX = 96;
        private static int SEVENTEEN = 17;
        private static int ONE_HUNDRED_SEVENTY_FOUR = 174;
        private static int EIGHTY = 80;
        private static int LEFT = 1;
        private static int RIGHT = 2;
        private static int UP = 3;
        //private static int DOWN = 4;

        public RopeSnakeEnemy RopeSnake { get; set; }
        public Rectangle dartRect;
        private Rectangle rightRect;
        private Rectangle leftRect;
        private Rectangle upRect;
        private Rectangle downRect;

        private int Direction;
        private int distance;
        
        public Vector2 hitBoxPos;
        public Vector2 linkPos;


        public RopeSnakeAI(RopeSnakeEnemy ropesnake)
        {
            RopeSnake = ropesnake;
            hitBoxPos = RopeSnake.Position;
            Direction = RopeSnake.direction;

            rightRect = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
            leftRect = new Rectangle((int)hitBoxPos.X - ONE_HUNDRED_SIXTY * Global.Var.SCALE, (int)hitBoxPos.Y, ONE_HUNDRED_SIXTY * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
            upRect = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y - NINETY_SIX * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE);
            downRect = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, SEVENTEEN * Global.Var.SCALE, EIGHTY * Global.Var.SCALE);

            dartRect = rightRect;
        }

        public void Update()
        {
            /*
            if (RopeSnake.dartDist > distance)
                RopeSnake.EndDart();
            */

            if (Direction != RopeSnake.direction)
            {
                Direction = RopeSnake.direction;
                ChangeSightLine();
            }
            hitBoxPos = RopeSnake.Position;

            if (Direction != LEFT)
                dartRect.X = (int)hitBoxPos.X;
            else
                dartRect.X = (int)hitBoxPos.X - ONE_HUNDRED_SIXTY * Global.Var.SCALE;

            if (Direction != UP)
                dartRect.Y = (int)hitBoxPos.Y;
            else
                dartRect.Y = (int)hitBoxPos.Y - NINETY_SIX * Global.Var.SCALE;

            CheckCollision();
        }

        private void ChangeSightLine()
        {
            /*Get the rectangle that represents the "sight" of the ropesnake*/
            if (Direction == RIGHT)
                dartRect = rightRect;
            else if (Direction == LEFT)
                dartRect = leftRect;
            else if (Direction == UP)
                dartRect = upRect;
            else
                dartRect = downRect;
        }

        public void CheckCollision()
        {
            distance = CollisionDetector.Instance.LinkInSight(dartRect, Direction);
            if ( distance != -1 ) /*-1 implies it is not going to dart*/
                RopeSnake.BeginDart(distance);
        }
    }
}
