using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.HudMenu
{
    public class HudInitializer
    {
        private IHud Hud;
        private float x; private float y;
        private int i; private int j;

        private const int HUD_SQUARE_WIDTH = 8;

        //IN-GAME HUD CONSTANTS
        private const int IN_GAME_HUD_X = 0;
        private const int IN_GAME_HUD_Y = 0;
        private const int HEALTH_COLUMN = 2;
        private const int HEALTH_ROW = 8; 
        private const int HEALTH_Y = 32;
        private const int HEALTH_X = 176;
        private const int ITEM_COLUMN = 4;
        private const int ITEM_ROW = 3;
        private const int ITEM_Y = 16;
        private const int ITEM_X = 96;
        private const int A_B_BUTTON_Y = 24;
        private const int A_BUTTON_X = 152;
        private const int B_BUTTON_X = 128;
        private const int EMPTY_SECOND_ROW = 1;

        //MINI MAP HUD CONSTANTS
        private const int MINIMAP_HUD_X = 16;
        private const int MINIMAP_HUD_Y = 8;
        private const int LEVEL_NUM_X = 64;
        private const int LEVEL_NUM_Y = 8;
        private const int MINIMAP_COLUMN = 4;
        private const int MINIMAP_ROW = 8;
        private const int INSIDE_MAP_X = 16;
        private const int INSIDE_MAP_Y = 16;


        public HudInitializer(IHud hud)
        {
            Hud = hud;
        }

        public void InitializeInGameHud()
        {
            //HUD BACKGROUND
            Hud.Icons.Add(new InGameHudEntity(new Vector2(IN_GAME_HUD_X, IN_GAME_HUD_Y)));

            //HEALTH
            y = HEALTH_Y;
            for (i = 0; i < HEALTH_COLUMN; i++)
            {
                x = HEALTH_X;
                for (j = 0; j < HEALTH_ROW; j++)
                {
                    Hud.Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + HUD_SQUARE_WIDTH;
                }
                y = y + HUD_SQUARE_WIDTH;
            }

            //ITEMS
            y = ITEM_Y;
            for (i = 0; i < ITEM_COLUMN; i++)
            {
                x = ITEM_X;
                for (j = 0; j < ITEM_ROW; j++)
                {
                    if (j == 0 && i != EMPTY_SECOND_ROW)
                    {
                        Hud.Icons.Add(new LetterX(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else if (j == 1 && i != EMPTY_SECOND_ROW)
                    {
                        Hud.Icons.Add(new Number0(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else
                    {
                        Hud.Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    x = x + HUD_SQUARE_WIDTH;
                }
                y = y + HUD_SQUARE_WIDTH;
            }

            //B BUTTON
            Hud.Icons.Add(new BlackLongIcon(new Vector2(B_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            //A BUTTON
            Hud.Icons.Add(new BlackLongIcon(new Vector2(A_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
            //SWORD
            Hud.Icons.Add(new SwordIcon(new Vector2(A_BUTTON_X * Global.Var.SCALE, A_B_BUTTON_Y * Global.Var.SCALE)));
        }

        public void InitializeMiniMap()
        {
            Hud.Icons.Add(new MiniMapEntity(new Vector2(MINIMAP_HUD_X * Global.Var.SCALE, MINIMAP_HUD_Y * Global.Var.SCALE)));
            Hud.Icons.Add(new Number1(new Vector2(LEVEL_NUM_X * Global.Var.SCALE, LEVEL_NUM_Y * Global.Var.SCALE)));

            y = INSIDE_MAP_Y;
            for (i = 0; i < MINIMAP_COLUMN; i++)
            {
                x = INSIDE_MAP_X;
                for (j = 0; j < MINIMAP_ROW; j++)
                {
                    Hud.Icons.Add(new BlackSquareIcon(new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + HUD_SQUARE_WIDTH;
                }
                y = y + HUD_SQUARE_WIDTH;
            }
        }
    }
}
