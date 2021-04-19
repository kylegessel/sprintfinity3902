using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace Sprintfinity3902.Dungeon
{
    public class DungeonGenerator
    {

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
            DirectoryInfo generatedDirectory = new DirectoryInfo(@"..\..\..\Content\GeneratedRooms\");
            if (!generatedDirectory.Exists) return;
            foreach (FileInfo file in generatedDirectory.GetFiles())
            {
                file.Delete();
            }

        }

        public int PopulateRooms()
        {
            HashSet<Point> RoomLocations = new HashSet<Point>();
            Random random = new Random();
            HashSet<Point> availableRooms = new HashSet<Point>();
            int id;


            Point currentPoint = new Point(random.Next(1, 8), random.Next(1, 8));
            RoomLocations.Add(currentPoint);

            for (int i=0; i<32; i++)
            {

                if (currentPoint.X < 8)
                {
                    availableRooms.Add(new Point(currentPoint.X + 1, currentPoint.Y));
                }
                if (currentPoint.X > 1)
                {
                    availableRooms.Add(new Point(currentPoint.X - 1, currentPoint.Y));
                }
                if (currentPoint.X < 8)
                {
                   availableRooms.Add(new Point(currentPoint.X, currentPoint.Y + 1));
                }
                if (currentPoint.X > 1)
                {
                    availableRooms.Add(new Point(currentPoint.X, currentPoint.Y - 1));
                }


                //INEFFECIENT AS HELLLLLL
                currentPoint = availableRooms.ElementAt(random.Next(availableRooms.Count));

                RoomLocations.Add(currentPoint);
            }

            int j = 1;
            var LocationId = new Dictionary<Point, int>();
            int numTemplates = new DirectoryInfo(@"..\..\..\Content\RoomTemplates\").GetFiles().Length;
            Debug.WriteLine("Found" + numTemplates + "temp");
            foreach (Point room in RoomLocations)
            {
                File.Copy(@"..\..\..\Content\RoomTemplates\Room" + random.Next(1, numTemplates + 1) + ".csv", @"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv");
                LocationId.Add(room, j);
                j++;
            }

            //setup doors
            j = 1;
            foreach (Point room in RoomLocations)
            {
                
                if (RoomLocations.Contains(new Point(room.X + 1,room.Y)))
                {
                    id = LocationId.GetValueOrDefault(new Point(room.X + 1, room.Y));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "ODRR, "+ id +",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "WALR, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X - 1, room.Y)))
                {
                    id = LocationId.GetValueOrDefault(new Point(room.X - 1, room.Y));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "ODRL, " + id + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "WALL, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X, room.Y + 1)))
                {
                    id = LocationId.GetValueOrDefault(new Point(room.X, room.Y+1));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "ODRB, " + id + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "WALB, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X, room.Y-1)))
                {
                    id = LocationId.GetValueOrDefault(new Point(room.X, room.Y-1));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "ODRT, " + id + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "WALT, -1,,,,,,,,,,\n");
                }





                File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", room.X + "," + room.Y + ",,,,,,,,,,,\n");
                File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + j + ".csv", "1\n");

                j++;
            }

            return j;

                
               
        }
    }
}
