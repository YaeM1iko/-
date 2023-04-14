using System;
using System.Windows.Input;
using CommandSystem;
using RemoteAdmin;
using ICommand = CommandSystem.ICommand;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class HelloWorld : ICommand
    {
        public string Command { get; } = "hello1";
        public string[] Aliases { get; } = { "helloworld" };
        public string Description { get; } = "A command that says hello to the world.";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player)
            {
                response = $"Hello, {player.Nickname}";
                return false;
            }
            else
            {
                response = "World!";
                return true;
            }
        }
    }
}