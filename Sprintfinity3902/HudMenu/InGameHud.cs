using Microsoft.Xna.Framework;
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
        private HudNumberManager hudNumberManager;
        private HudHeartManager hudHeartManager;
        private HudInitializer hudInitializer;
        public List<IEntity> Icons { get; set; }

        public InGameHud(Game1 game)
        {
            Game = game;
            Link = Game.link;
            Icons = new List<IEntity>();
            hudNumberManager = new HudNumberManager(this);
            hudHeartManager = new HudHeartManager(this);
            hudInitializer = new HudInitializer(this);

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
            //Private method calls to initialize black boxes at start
            //Private method calls to check conditionals and add new icons as needed
        }

        private void Initialize()
        {
            hudInitializer.InitializeInGameHud();
        }

        private void UpdateHearts()
        {
            double maxHealth = Link.MAX_HEALTH;
            double currentHealth = Link.linkHealth;

            hudHeartManager.UpdateHearts(maxHealth, currentHealth);
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
