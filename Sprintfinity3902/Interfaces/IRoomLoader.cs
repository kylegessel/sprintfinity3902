namespace Sprintfinity3902.Interfaces
{
    public interface IRoomLoader
    {
        public void Initialize(IRoom room);
        public void Build();
        public void BuildWallAndFloor(string input);
        public void BuildBlocks(string input);
        public void BuildDoors(string input, string destination);
    }
}
