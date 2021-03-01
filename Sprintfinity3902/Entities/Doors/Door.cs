using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.States.Door;

namespace Sprintfinity3902.Entities.Doors
{
    public class Door : AbstractEntity
    {
        private IDoorState _currentState;

        public IDoorState CurrentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
            }
        }

        public IDoorState wallTop { get; set; }
        public IDoorState wallBottom { get; set; }
        public IDoorState wallLeft { get; set; }
        public IDoorState wallRight { get; set; }
        public IDoorState openDoorTop { get; set; }
        public IDoorState openDoorBottom { get; set; }
        public IDoorState openDoorLeft { get; set; }
        public IDoorState openDoorRight { get; set; }

        public int DoorDestination { get; set; }




        public Door(Vector2 position)
        {
            Position = position;
            CurrentState = new WallTopState(this);
            wallTop = CurrentState;
            wallBottom = new WallBottomState(this);
            wallLeft = new WallLeftState(this);
            wallRight = new WallRightState(this);
            openDoorTop = new OpenDoorTopState(this);
            openDoorBottom = new OpenDoorBottomState(this);
            openDoorLeft = new OpenDoorLeftState(this);
            openDoorRight = new OpenDoorRightState(this);
            
        }

        public void SetState(IDoorState state)
        {
            Vector2 pos = Position;
            CurrentState = state;
            Position = pos;
        }

        public void Open()
        {
            CurrentState.Open();
        }

        public void Close()
        {
            CurrentState.Close();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Sprite.Draw(spriteBatch, Position, Color.White);
        }
        public override void Update(GameTime gameTime)
        {
            CurrentState.Sprite.Update(gameTime);
        }
    }
}

