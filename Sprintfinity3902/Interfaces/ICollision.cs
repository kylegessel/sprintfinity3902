namespace Sprintfinity3902.Interfaces
{
    public interface ICollision
    {
        //The side refers to where the moving entity is (Link or enemy)
        enum CollisionSide
        {
            TOP,
            RIGHT,
            BOTTOM,
            LEFT
        }

        public void reflectMovingEntity(IEntity movingEntity, CollisionSide side);

    }
}
