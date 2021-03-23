using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.HudMenu
{
    public class HudHeartManager
    {
        private IHud Hud;
        private float x; private float y;
        private int i;

        public HudHeartManager(InGameHud hud)
        {
            Hud = hud;
        }

        public void UpdateHearts(double maxHealth, double currentHealth)
        {
            double heartAmount = 2;
            double maxHealth_InHearts = maxHealth / heartAmount;
            double health_InHearts = currentHealth / heartAmount;

            x = 176;
            y = 40;
            for (i = 0; i < maxHealth_InHearts; i++)
            {
                health_InHearts--;
                if (health_InHearts >= 0)
                {
                    Hud.Icons.Add(new HeartFullIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                else if (health_InHearts < 0 && health_InHearts > -1)
                {
                    Hud.Icons.Add(new HeartHalfIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                else if (health_InHearts <= -1)
                {
                    Hud.Icons.Add(new HeartEmptyIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                x = x + 8;
            }
        }
    }
}
