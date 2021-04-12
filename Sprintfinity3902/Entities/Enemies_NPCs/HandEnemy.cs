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

        private static float INITIAL_SPEED = .4f;
        private static int ONE = 1;
        private static int FIVE = 5;
        private static int TWO_HUNDRED_TWENTY = 220;
        private static int SIXTY = 60;
        private static int MOD_BOUND = 12;
        private static int SIX = 6;
        private static int NINE = 9;
        private static int THIRTY = 30;
        private static int THREE = 3;
        private static float ANIMATION_DURATION = 2000;

        private int count;
        private Direction direction;
        private int waitTime;
        private int health;
        private int counter;
        private float speed;
        private Boolean decorate;
        private int enemyID;
        private HandAI _AI;
        private IPlayer link;

        private bool _caughtLink;
        private static bool caughtLink;
        private double animationCounter;
        private Vector2 savedPos;
        private IRoom room;

        public HandEnemy(Vector2 pos, IPlayer player, IRoom _room)
        {
            Sprite = EnemySpriteFactory.Instance.CreateHandEnemy();
            Position = pos;
            health = 3;
            speed = INITIAL_SPEED;
            color = Color.White;
            _AI = new HandAI(_room, this);
            link = player;
            _caughtLink = false;
            animationCounter = 0.0;
            room = _room;
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (_caughtLink) {
                double percentComplete = (animationCounter / ANIMATION_DURATION);
                this.color = Color.FromNonPremultiplied(new Vector4(1, 1, 1, Math.Max(0, 1 - (float)percentComplete)));
                PlayerSpriteFactory.Instance.CreateLinkDownSprite().Draw(spriteBatch, Position, this.color);
            }
            Sprite.Draw(spriteBatch, Position, this.color);
        }

        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection, IRoom room)
        {
            this.enemyID = enemyID;
            health = health - damage;
            count = ONE;
            waitTime = THIRTY;
            decorate = true;
            direction = projDirection;
            speed = (float)ONE;
            return health;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

            // No one caught link or I caught link
            if (!HandEnemy.caughtLink || _caughtLink) {

                double percentComplete = (animationCounter / ANIMATION_DURATION);

                if (percentComplete >= 1.0) {
                    link.STATIC = false;
                    color = Color.White;
                    CollisionDetector.Instance.Pause();
                    link.TogglePlayerVisible();
                    HandEnemy.caughtLink = false;
                    _caughtLink = false;
                    speed = INITIAL_SPEED;
                    room.enemies.Remove(enemyID);

                }

                // this caught link, increment animation counter
                if (_caughtLink) animationCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                Move();

                if (!this._caughtLink && link.GetBoundingRect().Intersects(GetBoundingRect())) {
                    SoundManager.Instance.PauseAll();
                    link.STATIC = true;
                    SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Link_Die).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
                    CollisionDetector.Instance.Pause();
                    color = Color.Black;
                    link.RemoveDecorator();
                    link.TogglePlayerVisible();
                    //link.Collidable = false;
                    HandEnemy.caughtLink = true;
                    _caughtLink = true;
                    speed = 2;
                    savedPos = new Vector2(Position.X, Position.Y);
                }
            }
            
            SetStepSize(speed);
            if (decorate) Decorate();
        }

        public void Decorate()
        {
            counter = count % MOD_BOUND;
            if (counter < THREE) {
                color = Color.Aqua;
            } else if (counter < SIX) {
                color = Color.Red;
            } else if (counter < NINE) {
                color = Color.White;
            } else {
                color = Color.Blue;
            }
        }

        public override void Move()
        {
            if (this._caughtLink) {

                double percentComplete = (animationCounter / ANIMATION_DURATION);


                Position = new Vector2(
                    (float)(savedPos.X + 100 * percentComplete * Global.Var.SCALE * Math.Cos(percentComplete * 2 * Math.PI * 2)),
                    (float)(savedPos.Y + 100 * percentComplete * Global.Var.SCALE * Math.Sin(percentComplete * 2 * Math.PI * 2))
                );

                return;
            }

            if (count == 0) {
                waitTime = new Random().Next(SIXTY, TWO_HUNDRED_TWENTY);
                count++;
            } else if (count == waitTime) {
                direction = intToDirection(new Random().Next(ONE, FIVE));
                speed = INITIAL_SPEED;
                count = Global.Var.ZERO;
                if (decorate) {
                    decorate = false;
                    speed *= 1.2f;
                    color = Color.White;
                }
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
            count++;
        }
    }
}
