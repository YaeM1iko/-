using System;
using CommandSystem;
using Exiled.API.Features;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Apart : ICommand
    {
        public string Command { get; } = "apart";
        public string[] Aliases { get; } = { };
        public string Description { get; } =
            "Предмет с рук удаляется и, в зависимости от качества, добавляется какое-то количество очков создания.";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var ply = Player.Get((sender as CommandSender)?.SenderId);
            if (ply == null)
            {
                response = "не нашло чурку!";
                return false;
            }
            
            if (!Features.SCP1956Controller.IsThereSCP(ply))
            {
                response = "купи випку и пиши приходи снова!";
                return false;
            }
            
            return Features.SCP1956Controller.StartApart(ply, out response);;
        }
    }
}