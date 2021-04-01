using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class InGameHud : AbstractHud
    {
        private Game1 Game;
        private IPlayer Link;
        private HudNumberManager hudNumberManager;
        private HudHeartManager hudHeartManager;
        private HudInitializer hudInitializer;

        public InGameHud(Game1 game)
        {
            Game = game;
            Link = Game.playerCharacter;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudNumberManager = new HudNumberManager(this);
            hudHeartManager = new HudHeartManager(this);
            hudInitializer = new HudInitializer(this);

            Initialize();
        }

        public override void Update(GameTime gameTime)
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

        public override void Initialize()
        {
            hudInitializer.InitializeInGameHud();
        }

        private void UpdateHearts()
        {
            double maxHealth = Link.MaxHealth;
            double currentHealth = Link.LinkHealth;

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
                hudNumberManager.BombNumbers(bombNum);
            }
        }
    }
}
