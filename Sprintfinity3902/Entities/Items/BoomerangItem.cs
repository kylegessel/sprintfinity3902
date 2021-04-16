using Microsoft.Xna.Framework;
using Sprintfinity3902.Entities.Items;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.SpriteFactories;
using System;

namespace Sprintfinity3902.Entities
{
    public class BoomerangItem : AbstractItem, IEnemy, IBoomerang
    {

        private static int TWO = 2;
        private static int SIXTY = 60;
        private static int STUN_LENGTH = 120;
        private float F_THIRTEEN_DOT_TWO = 13.2f;
        private int FOUR = 4;
        private int TEN = 10;
        private int THREE = 3;
        private int ONE_THOUSAND = 1000;
        private int THIRTEEN = 13;
        private int SIX = 6;

        IPlayer PlayerCharacter;
        GoriyaEnemy Goriya;
        Boolean ItemUse;
        Boolean PlayerUse;
        Boolean GoriyaUse;
        Boolean bounce;
        int MoveUseCount;
        int MaxMoveUseCount;
        IPlayerState FiringStatePlayer;
        IEnemyState FiringStateGoriya;
        IEntity Entity;
        float XDiff;
        float YDiff;
        float BoomerangOutChange;
        public Direction FireDirection { get; set; }
        public int EnemyHealth { get; set; }
        public int EnemyAttack { get; set; }


        public BoomerangItem()
        {
            Sprite = ItemSpriteFactory.Instance.CreateBoomerangItem();
            Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
            ItemUse = false;
            bounce = false;
            EnemyHealth = 1;
            EnemyAttack = 1;
            MoveUseCount = 1;
            ID = IItem.ITEMS.BOOMERANG;
            MaxMoveUseCount = 120;
        }

        public Boolean getItemUse()
        {
            return ItemUse;
        }

        public void doneUsing()
        {
            GoriyaUse = false;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (ItemUse)
            {
                MoveItem();
            }
        }

        public void MoveItem()
        {
            // Calculate how far away the boomerang presently is.
            XDiff = Position.X - Entity.Position.X;
            YDiff = Position.Y - Entity.Position.Y;

            if (MoveUseCount <= SIXTY && !bounce)
            {
                FireItem();
            }
            else if ((Math.Abs(XDiff) <= Global.Var.TILE_SIZE * Global.Var.SCALE) && (Math.Abs(YDiff) <= Global.Var.TILE_SIZE * Global.Var.SCALE))
            {
                // When the boomerang returns, reset to initial position.
                ResetItem();
            }
            else
            {
                Return();
            }

            MoveUseCount++;
        }

        public void FireItem()
        {
            // Calcuate how much we want the boomerang to change by, slowing down over time.
            BoomerangOutChange = (THIRTEEN - (MoveUseCount / SIX));
            if (FireDirection == Direction.DOWN)
            {
                Position = new Vector2(Position.X, Position.Y + BoomerangOutChange);
            }
            else if (FireDirection == Direction.UP)
            {
                Position = new Vector2(Position.X, Position.Y - BoomerangOutChange);
            }
            else if (FireDirection == Direction.LEFT)
            {
                Position = new Vector2(Position.X - BoomerangOutChange, Position.Y);
            }
            else if (FireDirection == Direction.RIGHT)
            {
                Position = new Vector2(Position.X + BoomerangOutChange, Position.Y);
            }
        }
        public void ResetItem()
        {
            ItemUse = false;
            MoveUseCount = 0;
            MaxMoveUseCount = 120;
            bounce = false;
            Position = new Vector2(-ONE_THOUSAND, -ONE_THOUSAND);
            if (PlayerUse)
            {
                PlayerCharacter.UseItem();
            }
            else if (GoriyaUse)
            {
                Goriya.UseItem();
            }
        }
        public void Return()
        {
            // Calculate the new position based on how many times the MoveItem function has been called.
            Position = new Vector2(Position.X - (XDiff / (MaxMoveUseCount - MoveUseCount)), Position.Y - (YDiff / (MaxMoveUseCount - MoveUseCount)));
        }
        public void UseItem(ILink player)
        {
            PlayerCharacter = (Player)player;
            FiringStatePlayer = PlayerCharacter.CurrentState;
            Entity = (IEntity)PlayerCharacter;

            if (FiringStatePlayer == PlayerCharacter.facingDownItem)
            {
                Position = new Vector2(PlayerCharacter.X + FOUR * Global.Var.SCALE, PlayerCharacter.Y + Global.Var.TILE_SIZE * Global.Var.SCALE);
                FireDirection = Direction.DOWN;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingUpItem)
            {
                Position = new Vector2(PlayerCharacter.X + THREE * Global.Var.SCALE, PlayerCharacter.Y - TEN * Global.Var.SCALE);
                FireDirection = Direction.UP;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingLeftItem)
            {
                Position = new Vector2(PlayerCharacter.X - TEN * Global.Var.SCALE, PlayerCharacter.Y + FOUR * Global.Var.SCALE);
                FireDirection = Direction.LEFT;
            }
            else if (FiringStatePlayer == PlayerCharacter.facingRightItem)
            {
                Position = new Vector2(PlayerCharacter.X + F_THIRTEEN_DOT_TWO * Global.Var.SCALE, PlayerCharacter.Y + FOUR * Global.Var.SCALE);
                FireDirection = Direction.RIGHT;
            }
            ItemUse = true;
            PlayerUse = true;
            GoriyaUse = false;
        }

        public void UseItem(GoriyaEnemy goriya)
        {
            Goriya = goriya;
            FiringStateGoriya = Goriya.CurrentState;
            Entity = Goriya;

            if (FiringStateGoriya == Goriya.itemDown)
            {
                Position = new Vector2(Goriya.X + FOUR * Global.Var.SCALE, Goriya.Y + Global.Var.TILE_SIZE * Global.Var.SCALE);
                FireDirection = Direction.DOWN;
            }
            else if (FiringStateGoriya == Goriya.itemUp)
            {
                Position = new Vector2(Goriya.X + THREE * Global.Var.SCALE, Goriya.Y - TEN * Global.Var.SCALE); ;
                FireDirection = Direction.UP;
            }
            else if (FiringStateGoriya == Goriya.itemLeft)

            {
                Position = new Vector2(Goriya.X - TEN * Global.Var.SCALE, Goriya.Y + FOUR * Global.Var.SCALE);
                FireDirection = Direction.LEFT;
            }
            else if (FiringStateGoriya == Goriya.itemRight)
            {
                Position = new Vector2(Goriya.X + F_THIRTEEN_DOT_TWO * Global.Var.SCALE, Goriya.Y + FOUR * Global.Var.SCALE);
                FireDirection = Direction.RIGHT;
            }
            ItemUse = true;
            PlayerUse = false;
            GoriyaUse = true;
        }

        public Boolean Collide(int enemyID, IEnemy enemy, IRoom room)
        {
            if (MoveUseCount < SIXTY)
            {
                bounce = true;
                MaxMoveUseCount = MoveUseCount * TWO;
            }

            // This will always be 0, but for consistency sake.
            return enemy.HitRegister(enemyID, 0, STUN_LENGTH, this, AbstractEntity.Direction.NONE, room) <= 0;
        }

        public void Collide(IRoom room)
        {
            if (MoveUseCount < SIXTY)
            {
                bounce = true;
                MaxMoveUseCount = MoveUseCount * TWO;
            }
        }

        public int HitRegister(int enemyID, int damage, int stunLength, IEntity proj, Direction projDirection, IRoom room)
        {
            return 1;
        }
    }
}
