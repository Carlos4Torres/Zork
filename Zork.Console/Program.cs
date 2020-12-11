using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename;

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            Game.StartFromFile(gameFilename, input, output);
            Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");


            while (Game.Instance.IsRunning)
            {
                output.Write("\n> ");
                input.GetInput();
            }

            output.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}