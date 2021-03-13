using Microsoft.Xna.Framework;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class GelEnemy : AbstractEntity, IEnemy {
        private static int CELL_WIDTH = 16 * Global.Var.SCALE;
        private static int MOVEMENT_DURATION_MS = 200;

        private Random _rand;
        private int _waitTime;
        private double _totalElapsedTime;
        private int _direction;
        private int _health;
        private Vector2 _storedPos;

        private bool _isMoving;

        public GelEnemy()
        {
            _rand = new Random();
            _waitTime = 1200; // In milliseconds
            _totalElapsedTime = 0;
            _isMoving = false;
            _health = 1;

            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = new Vector2(750, 540);
        }
        public GelEnemy(Vector2 pos)
        {
            _rand = new Random();
            _waitTime = 1200; // In milliseconds
            _totalElapsedTime = 0;
            _isMoving = false;
            _health = 1;

            Sprite = EnemySpriteFactory.Instance.CreateGelEnemy();
            Position = pos;
        }

        public override void Update(GameTime gameTime) {
            Sprite.Update(gameTime);
            _totalElapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_isMoving) {
                moveSmoothly();
            } else if (_totalElapsedTime >= _waitTime) {
                Move();
            }
        }

        public override void Move() {
            if (_isMoving) return; // If outsider calls

            _storedPos = new Vector2(Position.X, Position.Y);
            _totalElapsedTime = 0.0;
            _isMoving = true;
            _direction = _rand.Next(0, 4);
        }

        private void moveSmoothly() {

            double percent = _totalElapsedTime / MOVEMENT_DURATION_MS;

            if (percent >= 1.0) {
                _isMoving = false;
                _totalElapsedTime = 0;
            }

            switch (_direction) {
                case 0:
                    X = (int)(_storedPos.X + percent*CELL_WIDTH);
                    break;
                case 1:
                    X = (int)(_storedPos.X - percent * CELL_WIDTH);
                    break;
                case 2:
                    Y = (int)(_storedPos.Y + percent * CELL_WIDTH);
                    break;
                case 3:
                    Y = (int)(_storedPos.Y - percent * CELL_WIDTH);
                    break;
            }
        }
        public int HitRegister(int enemyID, int damage, int stunLength, Direction projDirection)
        {
            _health = _health - damage;
            if (stunLength > 0)
            {
                _totalElapsedTime = 0.0;
                // convert from frames to milliseconds.
                _waitTime = stunLength * 60;
            }
            // Typical enemy would have code for projectile direction and causing the enemy to move backwards a few times.
            return _health;
        }
    }
}
