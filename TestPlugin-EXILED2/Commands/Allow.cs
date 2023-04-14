using System;
using CommandSystem;
using ICommand = CommandSystem.ICommand;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Allow : ICommand
    {
        public string Command { get; } = "allow";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "A command that is allowed";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "The command was a success!";
            return true;
        }
    }
}