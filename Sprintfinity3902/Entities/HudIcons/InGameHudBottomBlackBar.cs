using Microsoft.Xna.Framework;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.Entities
{
    public class InGameHudBottomBlackBar : AbstractEntity
    {
        public InGameHudBottomBlackBar(Vector2 pos)
        {
            Sprite = HudSpriteFactory.Instance.CreateInGameHudBottomBlackBarIcon();
            Position = pos;
        }
    }
}
