namespace Sprintfinity3902.Interfaces
{
    public interface IRoomLoader
    {
        void Initialize(IRoom room, bool useRoomGen);
        void Build();
        void BuildWallAndFloor(string input);
        void BuildBlocks(string input);
        void BuildDoors(string input, string destination);
    }
}
