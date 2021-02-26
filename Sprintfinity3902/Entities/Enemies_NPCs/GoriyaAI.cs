using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities.Enemies_NPCs
{
    public class GoriyaAI
    {
        private bool isMoving;
        private bool isThrowing;
        private bool isWaiting;
        private bool justWalked;
        private bool justThrew;
        private bool justWaited;
        private bool choiceMade;

        private int throwCounter;
        private int choice;
        private int count;

        public GoriyaEnemy Goriya { get; set; }

        public GoriyaAI(GoriyaEnemy goriya)
        {
            Goriya = goriya;
        }

        public void Update()
        {
            if (isMoving)
                Goriya.Move();
            else if (isThrowing)
                Goriya.UseItem();
            else if (isWaiting)
                Goriya.Wait();
            else
                Choose();
        }

        public void Choose()
        {
            choice = new Random().Next(1, 5);
            while (!choiceMade)
            {
                if (choice == 1)
                {
                    isMoving = true;
                    choiceMade = true;
                }
                else if (choice == 2)
                {
                    isThrowing = true;
                    choiceMade = true;
                }
                else if (choice == 3)
                {
                    isWaiting = true;
                    choiceMade = true;
                }
                else if (choice == 4)
                {
                    Goriya.ChangeDirection();
                }
                else
                {
                    choice = new Random().Next(1, 5);
                }
            }

        }
    }
}
