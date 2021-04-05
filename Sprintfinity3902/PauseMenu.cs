using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902
{
    public class PauseMenu :  Interfaces.IUpdateable
    {
        private int count;
        private Game1 Game;
        private IPlayer Link;
        private static int HUD_HEIGHT = 176;

        private bool direction;

        public PauseMenu(Game1 game)
        {
            /* We should ask him about casting game or if we can code to concrete instead of interface. */
            Game = game;
            Link = game.playerCharacter;
            direction = true;
            count = 0;

        }

        public void Update(GameTime gameTime)
        {

            if (Game.CurrentState.Equals(Game.PAUSED_TRANSITION)) {
                ChangePosition();
                count = count + 2 * Global.Var.SCALE;
                Link.Y = Link.Y + 2 * Global.Var.SCALE * (direction ? 1 : -1);

                /* Crucial Global.Var.SCALE remains an int so this equality is valid */
                if (count == HUD_HEIGHT * Global.Var.SCALE) {
                    Game.SetState(direction ? Game.PAUSED : Game.PLAYING);
                    direction = !direction;
                    count = 0;
                }

            } 
            
        }


        public void ChangePosition()
        {
            if (count == HUD_HEIGHT * Global.Var.SCALE) return ;

            int shiftAmount = 2 * Global.Var.SCALE * (direction ? 1 : -1);

            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().blocks) {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().enemies.Values) {
                entity.Y = entity.Y + shiftAmount;
            }

            foreach (IEntity entity in Game.dungeon.GetCurrentRoom().items)  {
                entity.Y = entity.Y + shiftAmount;
            }

            //foreach (IEntity proj in game.dungeon.linkProj) {
                //proj.Y = proj.Y + shiftAmount;
            //}
            
            foreach(IEntity garbage in Game.dungeon.GetCurrentRoom().garbage) {
                garbage.Y = garbage.Y + shiftAmount;
            }

            foreach (IHud hud in Game.huds) {
                hud.TranslateMatrix(new Vector2(0, shiftAmount));
            }

            foreach (IEntity door in Game.dungeon.GetCurrentRoom().doors) {
                door.Y = door.Y + shiftAmount;
            }

            // Case for the bomb as it doesn't work similarly to other projectiles.

            ((Dungeon.Dungeon)Game.dungeon).bombItem.Y = ((Dungeon.Dungeon)Game.dungeon).bombItem.Y + shiftAmount;
            ((Dungeon.Dungeon)Game.dungeon).bombExplosion.Y = ((Dungeon.Dungeon)Game.dungeon).bombExplosion.Y + shiftAmount;
            ((Dungeon.Dungeon)Game.dungeon).boomerangItem.Y = ((Dungeon.Dungeon)Game.dungeon).boomerangItem.Y + shiftAmount;
            ((Dungeon.Dungeon)Game.dungeon).bowArrow.Y = ((Dungeon.Dungeon)Game.dungeon).bowArrow.Y + shiftAmount;
        }

    }
}