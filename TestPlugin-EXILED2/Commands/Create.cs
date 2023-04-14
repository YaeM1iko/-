using System;
using CommandSystem;
using Exiled.API.Features;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Create : ICommand
    {
        public string Command { get; } = "create";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Все очки создания тратятся, и создаётся какой-то случайный предмет.";
        
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
                response = "Покупай випку и приходи снова!";
                return false;
            }
            
            return Features.SCP1956Controller.StartCreate(ply, out response);;
        }
    }
}