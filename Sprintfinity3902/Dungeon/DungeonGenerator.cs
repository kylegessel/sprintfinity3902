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
            foreach (FileInfo file in generatedDirectory.GetFiles())
            {
                file.Delete();
            }

        }

        public int PopulateRooms()
        {
            HashSet<Point> RoomLocations = new HashSet<Point>();
            HashSet<Point> FinalRooms = new HashSet<Point>();
            Random random = new Random();
            HashSet<Point> availableRooms = new HashSet<Point>();
            var LocationId = new Dictionary<Point, int>();
            int nextId;
            int id;

            int j = 1;

            Point currentPoint = new Point(random.Next(3, 5), random.Next(3, 5));
            RoomLocations.Add(currentPoint);
            LocationId.Add(currentPoint, j);
            j++;

            while(j <= 8)
            {

                if (currentPoint.X < 7)
                {
                    currentPoint.X++;
                    if (!RoomLocations.Contains(currentPoint)  && !FinalRooms.Contains(currentPoint))
                    {
                        availableRooms.Add(currentPoint);
                    }
                    currentPoint.X--;
                    
                }
                if (currentPoint.X > 0)
                {
                    currentPoint.X--;
                    if (!RoomLocations.Contains(currentPoint) && !FinalRooms.Contains(currentPoint))
                    {
                        availableRooms.Add(currentPoint);
                    }
                    currentPoint.X++;
                }
                if (currentPoint.Y < 7)
                {
                    currentPoint.Y++;
                    if (!RoomLocations.Contains(currentPoint) && !FinalRooms.Contains(currentPoint))
                    {
                        availableRooms.Add(currentPoint);
                    }
                    currentPoint.Y--;
                }
                if (currentPoint.Y > 0)
                {
                    currentPoint.Y--;
                    if (!RoomLocations.Contains(currentPoint) && !FinalRooms.Contains(currentPoint))
                    {
                        availableRooms.Add(currentPoint);
                    }
                    currentPoint.Y++;
                }


                //INEFFECIENT AS HELLLLLL
                currentPoint = availableRooms.ElementAt(random.Next(availableRooms.Count));
                //availableRooms.Remove(currentPoint);

                availableRooms.Clear();

                RoomLocations.Add(currentPoint);
                LocationId.Add(currentPoint, j);
                j++;

            }

            //int j = 1;
            //var LocationId = new Dictionary<Point, int>();
            //foreach (Point room in RoomLocations)
            

                
            //    j++;
            //}

            //setup doors
            
            foreach (Point room in RoomLocations)
            {
                id = LocationId.GetValueOrDefault(room);
                File.Copy(@"..\..\..\Content\RoomTemplates\Room" + random.Next(1, 4) + ".csv", @"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv");

                if (RoomLocations.Contains(new Point(room.X + 1,room.Y)))
                {
                    nextId = LocationId.GetValueOrDefault(new Point(room.X + 1, room.Y));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "ODRR, "+ nextId +",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "WALR, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X - 1, room.Y)))
                {
                    nextId = LocationId.GetValueOrDefault(new Point(room.X - 1, room.Y));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "ODRL, " + nextId + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "WALL, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X, room.Y + 1)))
                {
                    nextId = LocationId.GetValueOrDefault(new Point(room.X, room.Y+1));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "ODRB, " + nextId + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "WALB, -1,,,,,,,,,,\n");
                }

                if (RoomLocations.Contains(new Point(room.X, room.Y-1)))
                {
                    nextId = LocationId.GetValueOrDefault(new Point(room.X, room.Y-1));
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "ODRT, " + nextId + ",,,,,,,,,,,\n");
                }
                else
                {
                    File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "WALT, -1,,,,,,,,,,\n");
                }





                File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", room.X + "," + room.Y + ",,,,,,,,,,,\n");
                File.AppendAllText(@"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv", "1\n");
            }

            return j;

                
               
        }

        private void BuildBossAndTreasure()
        {

        }

        
    }
}
