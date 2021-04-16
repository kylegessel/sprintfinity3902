using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FairyItem : AbstractItem
    {

        private float F_DOT_FOUR = .4f;
        private int THIRTY = 30;
        private int NINETY  =  90;

        private Random rand = new Random();
        private int count;
        private int direction;
        private int waitTime;
        

        public FairyItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateFairyItem();
            Position = new Vector2(400, 600);
            ID = IItem.ITEMS.FAIRY;
        }

        public FairyItem(Vector2 pos)
        {
            Sprite = ItemSpriteFactory.Instance.CreateFairyItem();
            Position = pos;
            ID = IItem.ITEMS.FAIRY;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Move();
        }

        public override void Move()
        {

            if (count == 0)
            {
                waitTime = rand.Next(THIRTY, NINETY);
            }
            else if (count == waitTime)
            {
                // States for up, down, up right, up left, down left, down right.
                /*Leaving this magic number because it may break code below if its value is changed*/
                direction = rand.Next(1, 6);

                count = 0;
            }

            switch (direction)
            {

                case 1:
                    Y = Y - F_DOT_FOUR * Global.Var.SCALE;
                    break;
                case 2:
                    Y = Y + F_DOT_FOUR * Global.Var.SCALE;
                    break;
                case 3:
                    X = X + F_DOT_FOUR * Global.Var.SCALE;
                    Y = Y + F_DOT_FOUR * Global.Var.SCALE;
                    break;
                case 4:
                    X = X - F_DOT_FOUR * Global.Var.SCALE;
                    Y = Y + F_DOT_FOUR * Global.Var.SCALE;
                    break;
                case 5:
                    X = X - F_DOT_FOUR * Global.Var.SCALE;
                    Y = Y - F_DOT_FOUR * Global.Var.SCALE;
                    break;
                case 6:
                    X = X + F_DOT_FOUR * Global.Var.SCALE;
                    Y = Y - F_DOT_FOUR * Global.Var.SCALE;
                    break;

            }
            count++;
        }

        public override bool Pickup(IPlayer Link, IHud parent)
        {
            Link.LinkHealth = Link.MaxHealth;
            //HudMenu.InGameHud.Instance.UpdateHearts(Link.MaxHealth, Link.LinkHealth);
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Item).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);


            return false;
        }
    }
    
}
