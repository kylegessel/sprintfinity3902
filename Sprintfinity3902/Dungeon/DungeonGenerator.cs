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
        Random Random; 
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
            Random = new Random();

        }

        public int PopulateRooms()
        {
            HashSet<Point> RoomLocations = new HashSet<Point>();
            HashSet<Point> FinalRooms = new HashSet<Point>();
            
            HashSet<Point> availableRooms = new HashSet<Point>();
            Dictionary<Point, int> LocationId = new Dictionary<Point, int>();
            int nextId;
            int id;

            Point startPoint = new Point(Random.Next(3, 5), Random.Next(3, 5));
            RoomLocations.Add(startPoint);
            LocationId.Add(startPoint, 1);

            CreateNewRooms(8, false, startPoint, RoomLocations, FinalRooms, LocationId);
            
            
            foreach (Point room in RoomLocations)
            {
                id = LocationId.GetValueOrDefault(room);
                File.Copy(@"..\..\..\Content\RoomTemplates\Room" + Random.Next(1, 4) + ".csv", @"..\..\..\Content\GeneratedRooms\GenRoom" + id + ".csv");

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

            return RoomLocations.Count + FinalRooms.Count + 1;

                
               
        }

        private void BuildBossAndTreasure()
        {

        }

        private void CreateNewRooms(int totalRooms, bool snake, Point initialPoint, HashSet<Point> RoomLocations, HashSet<Point> FinalRooms, Dictionary<Point, int> LocationId)
        {
            int j = RoomLocations.Count + FinalRooms.Count + 1;
            HashSet<Point> availableRooms = new HashSet<Point>();
            Point currentPoint = initialPoint;
            while (j <= totalRooms)
            {

                if (currentPoint.X < 7)
                {
                    currentPoint.X++;
                    if (!RoomLocations.Contains(currentPoint) && !FinalRooms.Contains(currentPoint))
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
                currentPoint = availableRooms.ElementAt(Random.Next(availableRooms.Count));
                //availableRooms.Remove(currentPoint);



                if (snake)
                {
                    availableRooms.Clear();
                }
                else
                {
                    availableRooms.Remove(currentPoint);
                }


                RoomLocations.Add(currentPoint);
                LocationId.Add(currentPoint, j);
                j++;

            }
        }

        
    }
}
