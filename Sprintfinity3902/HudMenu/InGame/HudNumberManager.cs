using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.HudMenu
{
    public class HudNumberManager
    {
        private float x; private float y;
        private int i; private int j;
        private int digitColumns;

        private const int HUD_SQUARE_WIDTH = 8;
        private const int DOUBLE_DIGIT_COLUMNS = 2;
        private const int SINGLE_DIGIT_COLUMNS = 1;
        private const int SINGLES_PLACE = 1;
        private const int DOUBLES_PLACE = 0;
        private const int ITEM_COUNT_X = 104;
        private const int RUPEE_COUNT_Y = 16;
        private const int KEY_COUNT_Y = 32;
        private const int BOMB_COUNT_Y = 40;
        
        public HudNumberManager()
        {
        }

        public void RupeeNumbers(int rupeeNum)
        {
            x = ITEM_COUNT_X;
            y = RUPEE_COUNT_Y;
            digitColumns = isDoubleDigit(rupeeNum);

            for (j = 0; j < digitColumns; j++)
            {
                if(digitColumns == DOUBLE_DIGIT_COLUMNS)
                 {
                    if(j == DOUBLES_PLACE)
                    {
                        int doubleDigit = (rupeeNum / 10) % 10;
                        HudMenu.InGameHud.Instance.Icons.Add(GetDigit(doubleDigit, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else if (j == SINGLES_PLACE)
                    {
                        int singleDigit = rupeeNum % 10;
                        HudMenu.InGameHud.Instance.Icons.Add(GetDigit(singleDigit, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                }
               
                else if(digitColumns == SINGLE_DIGIT_COLUMNS)
                {
                    HudMenu.InGameHud.Instance.Icons.Add(GetDigit(rupeeNum, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                x = x + HUD_SQUARE_WIDTH;
            }
            y = y + HUD_SQUARE_WIDTH;
        }

        public void KeyNumbers(int keyNum)
        {
            y = KEY_COUNT_Y;
            for (i = 0; i < SINGLE_DIGIT_COLUMNS; i++)
            {
                x = ITEM_COUNT_X;
                for (j = 0; j < SINGLE_DIGIT_COLUMNS; j++)
                {
                    HudMenu.InGameHud.Instance.Icons.Add(GetDigit(keyNum, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + HUD_SQUARE_WIDTH;
                }
                y = y + HUD_SQUARE_WIDTH;
            }
        }

        public void BombNumbers(int keyNum)
        {
            y = BOMB_COUNT_Y;
            for (i = 0; i < SINGLE_DIGIT_COLUMNS; i++)
            {
                x = ITEM_COUNT_X;
                for (j = 0; j < SINGLE_DIGIT_COLUMNS; j++)
                {
                    HudMenu.InGameHud.Instance.Icons.Add(GetDigit(keyNum, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + HUD_SQUARE_WIDTH;
                }
                y = y + HUD_SQUARE_WIDTH;
            }
        }

        public int isDoubleDigit(int num)
        {
            if(num - 10 >= 0)
            {
                return DOUBLE_DIGIT_COLUMNS;
            }
            else
            {
                return SINGLE_DIGIT_COLUMNS;
            }
        }

        public IEntity GetDigit(int num, Vector2 pos)
        {
            IEntity returnEntity = new Number0(pos);

            switch (num)
            {
                case 0:
                    returnEntity = new Number0(pos);
                    break;
                case 1:
                    returnEntity = new Number1(pos);
                    break;
                case 2:
                    returnEntity =  new Number2(pos);
                    break;
                case 3:
                    returnEntity =  new Number3(pos);
                    break;
                case 4:
                    returnEntity = new Number4(pos);
                    break;
                case 5:
                    returnEntity = new Number5(pos);
                    break;
                case 6:
                    returnEntity = new Number6(pos);
                    break;
                case 7:
                    returnEntity = new Number7(pos);
                    break;
                case 8:
                    returnEntity = new Number8(pos);
                    break;
                case 9:
                    returnEntity = new Number9(pos);
                    break;
            }

            return returnEntity;


        }

    }
}
