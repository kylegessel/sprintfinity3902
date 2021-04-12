namespace Sprintfinity3902.Interfaces
{
    public interface IRoomLoader
    {
        void Initialize(IRoom room, Game1 gameInstance);
        void Build();
        void BuildWallAndFloor(string input);
        void BuildBlocks(string input);
        void BuildDoors(string input, string destination);
    }
}
