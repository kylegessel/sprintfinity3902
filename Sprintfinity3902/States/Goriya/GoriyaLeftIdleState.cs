﻿using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class GoriyaLeftIdleState : IGoriyaState
    {
        public GoriyaEnemy Goriya { get; set; }
        public ISprite Sprite { get; set; }
        public bool Start { get; set; }

        private int count;
        private int rnd;

        public GoriyaLeftIdleState(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            Sprite = EnemySpriteFactory.Instance.CreateGoriyaLeftEnemy();
            Sprite.Animation.IsPlaying = false;
            Start = false;
            count = 0;
            rnd = 0;
        }


        public void Move()
        {
            Goriya.SetState(Goriya.movingLeft);
            Goriya.CurrentState.Start = true;
            Goriya.Move();
        }

        public void Wait()
        {
            if (Start)
            {
                count = 0;
                Start = false;
                Sprite.Animation.Stop();
                rnd = new Random().Next(50, 90);
            }

            if (count == rnd)
            {
                Goriya.done = true;
            }
            else
            {
                count++;
            }

        }

        public void UseItem()
        {
            Goriya.SetState(Goriya.itemLeft);
            Goriya.CurrentState.Start = true;
            Goriya.UseItem();
        }

        public void Update()
        {
            Wait();
        }
    }
}