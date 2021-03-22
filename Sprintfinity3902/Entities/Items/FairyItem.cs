using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class FairyItem : AbstractItem
    {
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
                waitTime = rand.Next(30, 90);
            }
            else if (count == waitTime)
            {
                // States for up, down, up right, up left, down left, down right.
                direction = rand.Next(1, 6);

                count = 0;
            }

            switch (direction)
            {

                case 1:
                    Y = Y - .4f * Global.Var.SCALE;
                    break;
                case 2:
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 3:
                    X = X + .4f * Global.Var.SCALE;
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 4:
                    X = X - .4f * Global.Var.SCALE;
                    Y = Y + .4f * Global.Var.SCALE;
                    break;
                case 5:
                    X = X - .4f * Global.Var.SCALE;
                    Y = Y - .4f * Global.Var.SCALE;
                    break;
                case 6:
                    X = X + .4f * Global.Var.SCALE;
                    Y = Y - .4f * Global.Var.SCALE;
                    break;

            }
            count++;
        }
    }
    
}
