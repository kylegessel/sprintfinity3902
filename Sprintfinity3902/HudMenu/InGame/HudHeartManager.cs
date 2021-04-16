using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.HudMenu
{
    public class HudHeartManager
    {
        private float x; private float y;
        private int i;

        private const int HUD_SQUARE_WIDTH = 8;
        private const int HEART_AMOUNT = 2;
        private const int HEART_X = 176;
        private const int HEART_Y = 40;
        private const int FULL_HEART = 0;
        private const int EMPTY_HEART = -1;

        private IHud ingame;

        public HudHeartManager(IHud _ingame)
        {
            ingame = _ingame;
        }

        public void UpdateHearts(double maxHealth, double currentHealth)
        {
            double maxHealth_InHearts = maxHealth / HEART_AMOUNT;
            double health_InHearts = currentHealth / HEART_AMOUNT;

            x = HEART_X;
            y = HEART_Y;
            for (i = 0; i < maxHealth_InHearts; i++)
            {
                health_InHearts--;
                if (health_InHearts >= FULL_HEART)
                {
                    ((InGameHud)ingame).Icons.Add(new HeartFullIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                else if (health_InHearts < FULL_HEART && health_InHearts > EMPTY_HEART)
                {
                    ((InGameHud)ingame).Icons.Add(new HeartHalfIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                else if (health_InHearts <= EMPTY_HEART)
                {
                    ((InGameHud)ingame).Icons.Add(new HeartEmptyIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                x = x + HUD_SQUARE_WIDTH;
            }
        }
    }
}
