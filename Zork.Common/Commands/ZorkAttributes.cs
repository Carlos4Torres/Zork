using System;
using System.Collections.Generic;

namespace Zork
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandClassAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string CommandName { get; }

        public IEnumerable<string> Verbs { get; }

        public CommandAttribute(string commandName, string verb) :
            this(commandName, new string[] { verb })
        {
        }

        public CommandAttribute(string commandName, string[] verbs)
        {
            CommandName = commandName;
            Verbs = verbs;
        }
    }
}