using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class LinkMovementManager
    {
        private static int TWO_HUNDRED_TWENTY_FOUR = 224;
        private static int THIRTY_TWO = 32;
        private static int ONE_HUNDRED_NINETY_FOUR = 194;
        private static int NINETY_SIX = 96;
        private static float F_ONE_DOT_FIVE = 1.5f;

        private Player Link;

        public LinkMovementManager(Player link)
        {
            Link = link;
        }

        public void MoveLink(ICollision.CollisionSide side)
        {
            ICollision.CollisionSide CollisionSide = side;

            int top = NINETY_SIX * Global.Var.SCALE;
            int bot = ONE_HUNDRED_NINETY_FOUR * Global.Var.SCALE;
            int left = THIRTY_TWO * Global.Var.SCALE;
            int right = TWO_HUNDRED_TWENTY_FOUR * Global.Var.SCALE;
            //If you change the scaler to something larger than 1 Link can get pushed back through walls. 
            //start moving
            if (CollisionSide == ICollision.CollisionSide.BOTTOM)
            {
                //Will want this to be an animation. So slower!
                Link.Y += F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (Link.Y > bot) Link.Y = bot;
            }
            else if (CollisionSide == ICollision.CollisionSide.LEFT)
            {
                Link.X -= F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (Link.X < left) Link.X = left;
            }
            else if (CollisionSide == ICollision.CollisionSide.TOP)
            {
                Link.Y -= F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (Link.Y < top) Link.Y = top;
            }
            else
            {
                Link.X += F_ONE_DOT_FIVE * Global.Var.SCALE;
                if (Link.X > right) Link.X = right;
            }
        }

    }
}
