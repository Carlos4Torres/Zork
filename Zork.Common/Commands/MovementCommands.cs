using System;

namespace Zork
{
    [CommandClass]
    public static class MovementCommands
    {
        [Command("NORTH", new string[] { "NORTH", "N"})]
        public static void North(Game game, CommandContext commandContext) => Move(game, Directions.North);
        [Command( "SOUTH", new string[] { "SOUTH", "S"})]
        public static void South(Game game, CommandContext commandContext) => Move(game, Directions.South);
        [Command("EAST", new string[] { "EAST", "E"})]
        public static void East(Game game, CommandContext commandContext) => Move(game, Directions.East);
        [Command("WEST", new string[] { "WEST", "W"})]
        public static void West(Game game, CommandContext commandContext) => Move(game, Directions.West);

        private static void Move(Game game, Directions direction)
        {
            bool playerMoved = game.Player.Move(direction);
            if (playerMoved == false)
            {
                Console.WriteLine("The way is shut!");
            }
        }
    }
}
