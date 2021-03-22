using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Collision;

namespace Sprintfinity3902.Entities
{
    public class SpikeAI
    {

        private static int ONE_HUNDRED_SIXTY = 160;
        private static int NINETY_SIX = 96;
        private static int SEVENTEEN  = 17;
        private static int ONE_HUNDRED_SEVENTY_FOUR = 174;
        private static int EIGHTY = 80;

        public SpikeEnemy Spike { get; set; }
        public Rectangle rightRec;
        public Rectangle leftRec;
        public Rectangle upRec;
        public Rectangle downRec;

        private bool collideRight;
        private bool collideLeft;
        private bool collideUp;
        private bool collideDown;

        public Vector2 hitBoxPos;
        

        public SpikeAI(SpikeEnemy spike)
        {
            Spike = spike;
            hitBoxPos = Spike.Position;

            rightRec = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, ONE_HUNDRED_SEVENTY_FOUR * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
            leftRec = new Rectangle((int)hitBoxPos.X- ONE_HUNDRED_SIXTY * Global.Var.SCALE, (int)hitBoxPos.Y, ONE_HUNDRED_SIXTY * Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE);
            upRec = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y-NINETY_SIX*Global.Var.SCALE, SEVENTEEN * Global.Var.SCALE, NINETY_SIX * Global.Var.SCALE);
            downRec = new Rectangle((int)hitBoxPos.X, (int)hitBoxPos.Y, SEVENTEEN * Global.Var.SCALE, EIGHTY * Global.Var.SCALE);

            collideRight = false;
            collideLeft = false;
            collideUp = false;
            collideDown = false;
        }

        public void Update()
        {
            hitBoxPos = Spike.Position;

            rightRec.X = (int)hitBoxPos.X;
            rightRec.Y = (int)hitBoxPos.Y;

            leftRec.X = (int)hitBoxPos.X - ONE_HUNDRED_SIXTY * Global.Var.SCALE;
            leftRec.Y = (int)hitBoxPos.Y;

            upRec.X = (int)hitBoxPos.X;
            upRec.Y = (int)hitBoxPos.Y - NINETY_SIX * Global.Var.SCALE;

            downRec.X = (int)hitBoxPos.X;
            downRec.Y = (int)hitBoxPos.Y;

            CheckCollision();
        }

        public void CheckCollision()
        {
            collideRight = CollisionDetector.Instance.CheckSpecificCollision(rightRec);
            collideLeft = CollisionDetector.Instance.CheckSpecificCollision(leftRec);
            collideUp = CollisionDetector.Instance.CheckSpecificCollision(upRec);
            collideDown = CollisionDetector.Instance.CheckSpecificCollision(downRec);

            HandleCollision();
        }

        public void HandleCollision()
        {
            if(collideRight && Spike.CurrentState == Spike.idleState)
            {
                Spike.SetState(Spike.horizontalMovingForward);
            }
            else if (collideLeft && Spike.CurrentState == Spike.idleState)
            {
                Spike.SetState(Spike.horizontalMovingForward);
            }
            else if (collideUp && Spike.CurrentState == Spike.idleState)
            {
                Spike.SetState(Spike.verticalMovingForward);
            }
            else if (collideDown && Spike.CurrentState == Spike.idleState)
            {
                Spike.SetState(Spike.verticalMovingForward);
            }
        }
    }
}
