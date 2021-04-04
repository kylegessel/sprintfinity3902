using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Collision;
using Sprintfinity3902.Entities.Enemies_NPCs;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class HandEnemy : AbstractEntity, IEnemy
    {

        private static float F_DOT_THREE = .4f;
        private static int ONE = 1;
        private static  int FIVE = 5;
        private static int TWO_HUNDRED_TWENTY = 220;
        private static int SIXTY =  60;
        private static int MOD_BOUND  = 12;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int THIRTY = 30;
        private static int THREE = 3;

        private int count;
        private static int decorateTime = 80;
        private int health;
        private float speed;
        private AbstractEntity.Direction direction;
        private bool decorate;
        private int enemyID;
        private IPlayer link;
        private HandAI _AI;
        public static bool caughtLink;
        private bool _caughtLink;
        private IRoom room;
        private static float animation_duration = 2000;
        private double startTime;
        private Vector2 savedPos;

        public HandEnemy(Vector2 pos, IPlayer player, IRoom _room)
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = pos;
            health = THREE;
            speed = F_DOT_THREE;
            Color = Color.White;
            room = _room;
            link = player;
            _AI = new HandAI(_room, this);
            this._caughtLink = false;
            direction = AbstractEntity.Direction.LEFT;
            startTime = 0;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (_caughtLink) {
                double percentComplete = (startTime / animation_duration);
                this.Color = Color.FromNonPremultiplied(new Vector4(1, 1, 1, Math.Max(0, 1 - (float)percentComplete)));
                PlayerSpriteFactory.Instance.CreateLinkDownSprite().Draw(spriteBatch, Position, this.Color);
            }
            Sprite.Draw(spriteBatch, Position, this.Color);

            //ItemSpriteFactory.Instance.CreateBombItem().Draw(spriteBatch, new Vector2(32 * Global.Var.SCALE+ Global.Var.TILE_SIZE * Global.Var.SCALE*6, 96 * Global.Var.SCALE + Global.Var.SCALE*Global.Var.TILE_SIZE*6), Color.White);
            //ItemSpriteFactory.Instance.CreateBombItem().Draw(spriteBatch, new Vector2(32 * Global.Var.SCALE + Global.Var.TILE_SIZE * Global.Var.SCALE, 96 * Global.Var.SCALE + Global.Var.SCALE * Global.Var.TILE_SIZE), Color.White);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            this.enemyID = enemyID;
            health = health - damage;
            decorate = true;
            direction = projDirection;
            speed = (float)ONE;
            return health;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

            if (!HandEnemy.caughtLink || this._caughtLink) {

                if (this._caughtLink) startTime += gameTime.ElapsedGameTime.TotalMilliseconds;

                Move();


                if (!this._caughtLink && link.GetBoundingRect().Intersects(GetBoundingRect())) {
                    SoundManager.Instance.PauseAll();
                    link.STATIC = true;
                    SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Link_Die).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
                    CollisionDetector.Instance.Pause();
                    Color = Color.Black;
                    HandEnemy.caughtLink = true;
                    this._caughtLink = true;
                    //room.enemies.Remove(enemyID);
                    speed = 2;
                    savedPos = new Vector2(Position.X, Position.Y);
                }
            }

            if (_caughtLink) {
                //link.Position = Position;
            }

            SetStepSize(speed);
            if (decorate) Decorate();
        }

        public void Decorate()
        {
            int counter = count % MOD_BOUND;
            if (counter < THREE)
            {
                Color = Color.Aqua;
            }
            else if (counter < SIX)
            {
                Color = Color.Red;
            }
            else if (counter < NINE)
            {
                Color = Color.White;
            }
            else
            {
                Color = Color.Blue;
            }
            count++;
            if (count >= decorateTime) {
                count = 0;
                decorate = false;
                Color = Color.White;

                speed = F_DOT_THREE;
            }
        }

        public override void Move()
        {
            if (this._caughtLink) {

                double percentComplete = (startTime / animation_duration);


                Position = new Vector2(
                    (float) (savedPos.X + 100 * percentComplete * Global.Var.SCALE * Math.Cos(percentComplete*2 * Math.PI * 2)),
                    (float) (savedPos.Y + 100 * percentComplete * Global.Var.SCALE * Math.Sin(percentComplete*2 * Math.PI * 2))
                );

                return;
            }
            switch (decorate ? direction : _AI.WhichDirection(Position, link.Position)) {
                case Direction.LEFT:
                    X -= speed * Global.Var.SCALE;
                    break;
                case Direction.RIGHT:
                    X += speed * Global.Var.SCALE;
                    break;
                case Direction.UP:
                    Y -= speed * Global.Var.SCALE;
                    break;
                case Direction.DOWN:
                    Y += speed * Global.Var.SCALE;
                    break;
            }
        }
    }
}
