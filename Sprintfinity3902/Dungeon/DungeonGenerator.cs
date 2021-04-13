using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Sprintfinity3902.Dungeon
{
    public class DungeonGenerator
    {
        /* Used this private class for inventory hud, figured it would be helpful and fast */
        private class OrderedSet<T> : IList<T>
        {
            public T this[int index] { get => baseList[index]; set { baseList[index] = value; } }

            public int Count => baseList.Count;

            public bool IsReadOnly => false;

            private List<T> baseList;
            public OrderedSet()
            {
                baseList = new List<T>();
            }

            public void Add(T item)
            {
                if (baseList.Contains(item)) return;
                baseList.Add(item);
            }

            public void Clear() => baseList.Clear();
            public bool Contains(T item) => baseList.Contains(item);
            public void CopyTo(T[] array, int arrayIndex) => baseList.CopyTo(array, arrayIndex);
            public IEnumerator<T> GetEnumerator() => baseList.GetEnumerator();
            public int IndexOf(T item) => baseList.IndexOf(item);
            public void Insert(int index, T item) => baseList.Insert(index, item);
            public bool Remove(T item) => baseList.Remove(item);
            public void RemoveAt(int index) => baseList.RemoveAt(index);
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => baseList.GetEnumerator();
        }

        private static string CONTENT_DIRECTORY = @"..\..\..\Content\";
        private static int LOWER_BOUND_NUM_ROOMS = 10;
        private static int UPPER_BOUND_NUM_ROOMS = 40;

        private static int NUM_COLUMNS = 8;
        private static int NUM_ROWS = 8;

        /* DOWN, LEFT, UP, RIGHT */
        private static List<Point> OFFSETS = new List<Point>() { 
            new Point(0, -1),
            new Point(-1, 0),
            new Point(0, 1),
            new Point(1, 0)
        };

        private static string[] ORDERED_DOORS = new string[] {
                    "ODRT",
                    "ODRL",
                    "ODRB",
                    "ODRR"
                };

        private static string[] ORDERED_WALLS = new string[] {
                    "WALT",
                    "WALL",
                    "WALB",
                    "WALR"
            };

        private static DungeonGenerator instance;
        public static DungeonGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DungeonGenerator();
                }
                return instance;
            }
        }

        public void Initialize()
        {
            DirectoryInfo generatedDirectory = new DirectoryInfo(CONTENT_DIRECTORY + @"GeneratedRooms\");
            foreach (FileInfo file in generatedDirectory.GetFiles())
            {
                file.Delete();
            }

        }

        private bool isValidLocation(Point loc) {
            return loc.X >= 0 && loc.X < NUM_COLUMNS && loc.Y >= 0 && loc.Y < NUM_ROWS;
        }

        private void addPointToRoomLocationList(OrderedSet<Point> roomLocations, OrderedSet<Point> availableLocations, Point loc) {
            // Don't actually need this line since its a set
            //if (roomLocations.Contains(loc)) throw new Exception("Tried to add location that already exists in room locations");
            if (!isValidLocation(loc)) throw new Exception("Tried to add a location that is not valid");

            roomLocations.Add(loc);
            availableLocations.Remove(loc);

            foreach (Point p in OFFSETS.Where(p => isValidLocation(p + loc))) {
                Point potential = p + loc;
                if (roomLocations.Contains(potential)) continue;
                availableLocations.Add(potential);
            }

        }

        public int PopulateRooms()
        {
            OrderedSet<Point> roomLocations = new OrderedSet<Point>();
            Random random = new Random();
            OrderedSet<Point> availableRooms = new OrderedSet<Point>();

            int numRooms = random.Next(LOWER_BOUND_NUM_ROOMS, UPPER_BOUND_NUM_ROOMS + 1);

            for (int j = 0; j < numRooms; j++)
            {
                addPointToRoomLocationList(roomLocations, availableRooms, availableRooms.Count == 0 ? new Point(random.Next(NUM_COLUMNS), random.Next(NUM_ROWS)) : availableRooms[random.Next(availableRooms.Count)]);
            }

            var LocationId = new Dictionary<Point, int>();
            for (int j = 1; j <= roomLocations.Count; j++) {
                File.Copy(CONTENT_DIRECTORY + @"RoomTemplates\Room" + random.Next(1, 5) + ".csv", CONTENT_DIRECTORY + @"GeneratedRooms\GenRoom" + j + ".csv");
                LocationId.Add(roomLocations[j-1], j);
            }


            //setup doors + walls
            for (int j = 1; j <= roomLocations.Count; j++) {
                Point room = roomLocations[j-1];

                for (int i = 0; i < OFFSETS.Count; i++) {
                    if (roomLocations.Contains(OFFSETS[i])) {
                        int id = LocationId.GetValueOrDefault(OFFSETS[i] + room);
                        File.AppendAllText(CONTENT_DIRECTORY + @"GeneratedRooms\GenRoom" + j + ".csv", ORDERED_DOORS[i] + ", " + id + ",,,,,,,,,,,\n");
                    } else {
                        File.AppendAllText(CONTENT_DIRECTORY + @"GeneratedRooms\GenRoom" + j + ".csv", ORDERED_WALLS[i] + ", " + "-1,,,,,,,,,,\n");
                    }
                }

                File.AppendAllText(CONTENT_DIRECTORY + @"GeneratedRooms\GenRoom" + j + ".csv", room.X + "," + room.Y + ",,,,,,,,,,,\n");
                File.AppendAllText(CONTENT_DIRECTORY + @"GeneratedRooms\GenRoom" + j + ".csv", "1\n");

            }
            
            return roomLocations.Count;
        }
    }
}
