using System;

namespace Sprintfinity3902.Entities
{
    public class GoriyaAI
    {
        private static int ONE = 1;
        private static int TWO =2;
        private static int THREE=3;
        private static int FOUR = 4;
        private static int FIVE = 5;

        private bool justMoved;
        private bool justTurned;
        private bool choiceMade;
        private int moveCounter;
        private int waitCounter;
        private int throwCounter;
        private int choice;
        

        public GoriyaEnemy Goriya { get; set; }

        public GoriyaAI(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            justMoved = false;
            justTurned = false;
            choiceMade = false;
            moveCounter = 0;
            throwCounter = 0;
            choice = 0;
        }

        public void Choose()
        {
            choiceMade = false;
            choice = new Random().Next(ONE, FIVE);
            while (choiceMade == false)
            {
                if (choice == ONE && justMoved == false)
                {
                    choiceMade = true;
                    Goriya.Move();
                }
                else if (choice == TWO && throwCounter == Global.Var.ZERO)
                {
                    choiceMade = true;
                    Goriya.UseItem();
                }
                else if (choice == THREE && waitCounter == Global.Var.ZERO)
                {
                    choiceMade = true;
                    Goriya.Wait();
                }
                else if (choice == FOUR && justTurned == false)
                {
                    choiceMade = true;
                    Goriya.ChangeDirection();
                }
                else
                {
                    choice = new Random().Next(ONE, FIVE);
                }
            }
            SetCounters();

        }

        public void SetCounters()
        {
            if(choice == ONE) //Moved
            {
                moveCounter++;
                if (moveCounter == THREE)
                {
                    moveCounter = Global.Var.ZERO;
                    justMoved = true;
                }
                else
                    justMoved = false;
                if (waitCounter > Global.Var.ZERO)
                    waitCounter--;
                justTurned = false;
                if (throwCounter > Global.Var.ZERO)
                    throwCounter--;
            }
            else if(choice == TWO) //UsedItem
            {
                justMoved = false;
                if (waitCounter > Global.Var.ZERO)
                    waitCounter--;
                justTurned = false;
                throwCounter = TWO;
            }
            else if (choice == THREE) //Waited
            {
                justMoved = false;
                waitCounter = THREE;
                justTurned = false;
                if (throwCounter > Global.Var.ZERO)
                    throwCounter--;
            }
            else if (choice == FOUR) //ChangedDirection
            {
                justMoved = false;
                if (waitCounter > Global.Var.ZERO)
                    waitCounter--;
                justTurned = true;
                if (throwCounter > Global.Var.ZERO)
                    throwCounter--;
            }
        }
    }
}
