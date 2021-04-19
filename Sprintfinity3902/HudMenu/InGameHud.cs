using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.HudMenu
{
    public class InGameHud : AbstractHud
    {
        private HudNumberManager hudNumberManager;
        private HudHeartManager hudHeartManager;
        private HudInitializer hudInitializer;
        private const int B_BUTTON_X = 128;
        private const int A_B_BUTTON_Y = 24;

        public InGameHud()
        {
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, 0 * Global.Var.SCALE);
            hudNumberManager = new HudNumberManager(this);
            hudHeartManager = new HudHeartManager(this);
            hudInitializer = new HudInitializer(this);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Initialize()
        {
            hudInitializer.InitializeInGameHud();
        }

        public void UpdateHearts(double maxH, double currentH)
        {
            double maxHealth = maxH;
            double currentHealth = currentH;

            hudHeartManager.UpdateHearts(maxHealth, currentHealth);
        }

        public void UpdateRupees(int num)
        {
            int rupeeNum = num;
            hudNumberManager.RupeeNumbers(rupeeNum);
        }
        public void UpdateKeys(int num)
        {
            int keyNum = num;
            hudNumberManager.KeyNumbers(keyNum);
        }
        public void UpdateBomb(int num)
        {
            int bombNum = num;
            hudNumberManager.BombNumbers(bombNum);
        }
        public void UpdateItems(int rupee, int keys, int bomb)
        {
            UpdateRupees(rupee);
            UpdateKeys(keys);
            UpdateBomb(bomb);
        }

        public void UpdateSelectedItems(IPlayer.SelectableWeapons weapon)
        {

            if (weapon == IPlayer.SelectableWeapons.BOOMERANG)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BoomerangIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else if (weapon == IPlayer.SelectableWeapons.BOMB)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BombIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else if (weapon == IPlayer.SelectableWeapons.BOW)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new BowIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else if (weapon == IPlayer.SelectableWeapons.FLUTE)
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
                Icons.Add(new FluteIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
            else
            {
                Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            }
        }
    }
}
