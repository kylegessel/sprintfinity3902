using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprintfinity3902.Interfaces
{
    public interface ILink
    {
        ISprite Sprite { get; set; }
        Vector2 Position { get; set; }
        float X { get; set; }
        float Y { get; set; }
        

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Color color);
        void Move();
        void Attack();
        void SetState(IPlayerState state);
        void RemoveDecorator();
        void UseItem(IItem.ITEMS item);
        public void UseItem();
        void Pickup(IItem item);
        void DeathSpin(bool end);
        
    }
}

