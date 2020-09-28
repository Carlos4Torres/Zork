using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting;

namespace Zork
{
    class Program
    {
        /*private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }*/
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) 
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = ("Thank you for playing!");
                        break;
                    
                    case Commands.LOOK:
                        outputString = ("This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = $"You moved {command}.";
                        break;

                    default:
                        outputString = "Unknown Command.";
                        break;
                }

                Console.WriteLine(outputString);

            }       
        }
        /*
        private static bool Move(Commands command)
        {
            //Assert.IsTrue(IsDirection(command), "Invalid Direction.");
            bool IsValidMove = true;
            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.getLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.EAST when Location.Column < Rooms.getLength(1) - 1:
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
        }*/

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }
    }
}
