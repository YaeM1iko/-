using System;
using System.Text.RegularExpressions;
using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
using RemoteAdmin;
using TestPlugin_EXILED2.Features;
using UnityEngine;
using Round = PluginAPI.Core.Round;

namespace TestPlugin_EXILED2.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class SCP1956 : ICommand
    {
        public string Command { get; } = "scp1956";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "ОH SHIT! YOU ARE A ЧУРКА!";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 1)
            {
                response = "Usage: scp1956 [ID_PLAYER]";
                return false;
            }

            Player ply = Player.Get(arguments.At(0));
            if (ply == null)
            {
                response = $"Не нашло чурку: {arguments.At(0)}";
                return false;
            }

            if (!Round.IsRoundStarted)
            {
                response = $"To use this command, you need to start the round!";
                return false;
            }

            if (SCP1956Controller.IsThereSCP(ply))
            {
                response = $"Ты чурка номер SCP1956.";
                return false;
            }
            SCP1956Controller.SetSCP1956(ply, out response);

            return true;
        }
    }
}