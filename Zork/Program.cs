using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using Newtonsoft.Json;

namespace Zork
{
    internal class Program
    {
        private enum CommandLineArguments
        {
            RoomsFilename = 0
        }
        private enum Fields
        {
            Name = 0,
            Description
        }

        private static void InitializeRoomDescriptions(string roomsFilename) =>
        Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));

        public static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            const string defaultRoomsFilename = "Rooms.json";
            string roomsFilename = (args.Length > 0 ? args[(int)CommandLineArguments.RoomsFilename] : defaultRoomsFilename);
            InitializeRoomDescriptions(roomsFilename);




            Room previousRoom = null;
            Commands command = Commands.UNKNOWN;

            if (previousRoom != CurrentRoom)
            {
                previousRoom = CurrentRoom;
            }

            while (command != Commands.QUIT) 
            {
                Console.WriteLine(CurrentRoom);
                Console.WriteLine(CurrentRoom.Description);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    
                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is blocked!");
                        }
                        break;


                    default:
                        Console.WriteLine("Unknown Command.");
                        break;
                
                }
            }       
        }
        
        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid Direction.");

            bool IsValidMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;

                default:
                    IsValidMove = false;
                    break;

            }

            return IsValidMove;
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ?result : Commands.UNKNOWN;

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static Room[,] Rooms = {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }

        };

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST,
            Commands.LOOK
        };

        private static (int Row, int Column) Location = (1, 1);
    }
}
