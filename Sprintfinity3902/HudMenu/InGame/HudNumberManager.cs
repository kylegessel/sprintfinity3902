using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.HudMenu
{
    public class HudNumberManager
    {
        private InGameHud Hud;
        private float x; private float y;
        private int i; private int j;
        private int digits;
        
        public HudNumberManager(InGameHud hud)
        {
            Hud = hud;
            x = 0;
            y = 0;
        }

        public void RupeeNumbers(int rupeeNum)
        {
            x = 104;
            y = 16;
            digits = isDoubleDigit(rupeeNum);

            for (j = 0; j < digits; j++)
            {
                if(digits == 2)
                {
                    if(j == 0)
                    {
                        int doubleDigit = (rupeeNum / 10) % 10;
                        Hud.Icons.Add(GetDigit(doubleDigit, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                    else if (j == 1)
                    {
                        int singleDigit = rupeeNum % 10;
                        Hud.Icons.Add(GetDigit(singleDigit, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    }
                }
                else if(digits == 1)
                {
                    Hud.Icons.Add(GetDigit(rupeeNum, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                }
                x = x + 8;
            }
            y = y + 8;
        }

        public void KeyNumbers(int keyNum)
        {
            y = 32;
            for (i = 0; i < 1; i++)
            {
                x = 104;
                for (j = 0; j < 1; j++)
                {
                    Hud.Icons.Add(GetDigit(keyNum, new Vector2(x * Global.Var.SCALE, y * Global.Var.SCALE)));
                    x = x + 8;
                }
                y = y + 8;
            }
        }

        public int isDoubleDigit(int num)
        {
            if(num - 10 >= 0)
            {
                return 2;
            }
            else
            {
                return 1;
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
