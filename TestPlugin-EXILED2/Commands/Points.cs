using System;
using CommandSystem;
using Exiled.API.Features;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Points : ICommand
    {
        public string Command { get; } = "points";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Gets amount of point that you have.";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get((sender as CommandSender)?.SenderId);
            if (ply == null)
            {
                response = "нет чурок!";
                return false;
            }
            
            if (!Features.SCP1956Controller.IsThereSCP(ply))
            {
                response = "Покупай випку и приходи чурка!";
                return false;
            }

            var points = Features.SCP1956Controller.GetPoints(ply);
            response = $"У тебя {points} очков, чурка!";
            return true;
        }
    }
}