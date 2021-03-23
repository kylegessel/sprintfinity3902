﻿using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class InGameHud : IHud
    {
        private Game1 Game;
        private Player Link;
        private float x; private float y;
        private int i; private int j;
        private HudNumberManager hudNumberManager;
        private HudHeartManager hudHeartManager;
        public List<IEntity> Icons { get; set; }

        public InGameHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();
            hudNumberManager = new HudNumberManager(this);
            hudHeartManager = new HudHeartManager(this);

            AddIcons();
        }

        public void Update(GameTime gameTime)
        {
            if (Link.heartChanged)
            {
                UpdateHearts();
                Link.heartChanged = false;
            }

            if (Link.itemPickedUp)
            {
                UpdateItems();
                Link.itemPickedUp = false;
            }
        }

        public void AddIcons()
        {
            Initialize();
            StartingIcons();
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }

        private void Initialize()
        {
            //HUD BACKGROUND
            Icons.Add(new InGameHudEntity(new Vector2(0, 0)));

            //HEALTH
            y = 32;
            for (i = 0; i < 2; i++)
            {
                x = 176;
                for (j = 0; j < 8; j++)
                {
                    Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }

            //ITEMS
            y = 16;
            for(i = 0; i < 4; i++)
            {
                x = 96;
                for(j = 0; j < 3; j++)
                {
                    if(j == 0 && i != 1)
                    {
                        Icons.Add(new LetterX(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else if (j == 1 && i != 1)
                    {
                        Icons.Add(new Number0(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else
                    {
                        Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    x = x + 8;
                }
                y = y + 8;
            }

            //B BUTTON
            Icons.Add(new BlackLongIcon(new Vector2(128 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
            //A BUTTON
            Icons.Add(new BlackLongIcon(new Vector2(152 * Global.Var.SCALE, 24 * Global.Var.SCALE)));

        }

        private void StartingIcons()
        {

            //HEARTS
            int linkHearts = Link.MAX_HEALTH / 2;
            x = 176;
            y = 40;
            for(i = 0; i < linkHearts; i++)
            {
                Icons.Add(new HeartFullIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                x = x + 8;
            }

            //SWORD
            Icons.Add(new SwordIcon(new Vector2(152 * Global.Var.SCALE, 24 * Global.Var.SCALE)));
        }

        private void UpdateHearts()
        {
            int maxHearts = Link.MAX_HEALTH / 2;
            int currentHeart = (int)Math.Round((double)Link.linkHealth / 2, MidpointRounding.AwayFromZero);

            x = 176;
            y = 40;
            for(i = 1; i < currentHeart; i++)
            {
                x = x + 8;
            }

            if(Link.linkHealth % 2 != 0)
            {
                Icons.Add(new HeartHalfIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
            }
            else
            {
                Icons.Add(new HeartFullIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
            }

            for (i = currentHeart; i < maxHearts; i++)
            {
                x = x + 8;
                Icons.Add(new HeartEmptyIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
            }
            x = x - 8;
            for (i = currentHeart - 1; i > 1; i--)
            {
                x = x - 8;
                Icons.Add(new HeartFullIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
            }

        }

        private void UpdateItems()
        {
            int rupeeNum; int keyNum; int bombNum;

            if (Link.itemcount.ContainsKey(IItem.ITEMS.RUPEE))
            {
                rupeeNum = Link.itemcount[IItem.ITEMS.RUPEE];
                hudNumberManager.RupeeNumbers(rupeeNum);
            }

            if (Link.itemcount.ContainsKey(IItem.ITEMS.KEY))
            {
                keyNum = Link.itemcount[IItem.ITEMS.KEY];
                hudNumberManager.KeyNumbers(keyNum);

            }

            if (Link.itemcount.ContainsKey(IItem.ITEMS.BOMB))
            {
                bombNum = Link.itemcount[IItem.ITEMS.BOMB];
                //DisplayNumbers(bombNum);

            }
        }

    }
}
