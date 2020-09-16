using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT) 
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                //string outputString;
                switch (command)
                {
                    case Commands.LOOK:
                        Console.Write("This is an open field west of a white house, with a boarded front door. A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        command = Commands.LOOK;
                        break;

                    case Commands.NORTH:
                        Console.Write("You moved North.");
                        command = Commands.NORTH;
                        break;

                    case Commands.SOUTH:
                        Console.Write("You moved South.");
                        command = Commands.SOUTH;
                        break;

                    case Commands.EAST:
                        Console.Write("You moved East.");
                        command = Commands.EAST;
                        break;

                    case Commands.WEST:
                        Console.Write("You moved West.");
                        command = Commands.WEST;
                        break;

                    case Commands.QUIT:
                        Console.Write("Thank you for playing!");
                        break;

                    case Commands.UNKNOWN:
                        Console.Write("Unknown command.");
                        break;
                };

                //Console.WriteLine(outputString);

            }       
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }
    }
}
