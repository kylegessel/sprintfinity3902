using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities
{
    public class GoriyaAI
    {
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
            choice = new Random().Next(1, 5);
            while (choiceMade == false)
            {
                if (choice == 1 && justMoved == false)
                {
                    choiceMade = true;
                    Goriya.Move();
                }
                else if (choice == 2 && throwCounter == 0)
                {
                    choiceMade = true;
                    Goriya.UseItem();
                }
                else if (choice == 3 && waitCounter == 0)
                {
                    choiceMade = true;
                    Goriya.Wait();
                }
                else if (choice == 4 && justTurned == false)
                {
                    choiceMade = true;
                    Goriya.ChangeDirection();
                }
                else
                {
                    choice = new Random().Next(1, 5);
                }
            }
            SetCounters();

        }

        public void SetCounters()
        {
            if(choice == 1) //Moved
            {
                moveCounter++;
                if (moveCounter == 3)
                {
                    moveCounter = 0;
                    justMoved = true;
                }
                else
                    justMoved = false;
                if (waitCounter > 0)
                    waitCounter--;
                justTurned = false;
                if (throwCounter > 0)
                    throwCounter--;
            }
            else if(choice == 2) //UsedItem
            {
                justMoved = false;
                if (waitCounter > 0)
                    waitCounter--;
                justTurned = false;
                throwCounter = 2;
            }
            else if (choice == 3) //Waited
            {
                justMoved = false;
                waitCounter = 3;
                justTurned = false;
                if (throwCounter > 0)
                    throwCounter--;
            }
            else if (choice == 4) //ChangedDirection
            {
                justMoved = false;
                if (waitCounter > 0)
                    waitCounter--;
                justTurned = true;
                if (throwCounter > 0)
                    throwCounter--;
            }
        }
    }
}
