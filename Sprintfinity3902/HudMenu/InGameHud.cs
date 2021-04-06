using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
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
        private const int B_BUTTON_X = 128;
        private const int A_B_BUTTON_Y = 24;

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

            if (Link.selectedItemChanged)
            {
                UpdateSelectedItems();
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

        private void UpdateSelectedItems()
        {
            if(Link.SelectedWeapon == IPlayer.SelectableWeapons.BOOMERANG)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BoomerangIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else if (Link.SelectedWeapon == IPlayer.SelectableWeapons.BOMB)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BombIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else if (Link.SelectedWeapon == IPlayer.SelectableWeapons.BOW)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BowIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            Link.selectedItemChanged = false;
        }
    }
}
