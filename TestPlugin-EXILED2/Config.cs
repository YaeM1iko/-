using System.ComponentModel;
using Exiled.API.Interfaces;

namespace TestPlugin_EXILED2
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Sets the for message when someone joins the server. [PLAYER] will be replaced with the players name.")]
        public string JoinedMessage { get; set; } = "[PLAYER] has joined the server!";
        
        [Description("Sets the for message when someone leaves the server. [PLAYER] will be replaced with the players name.")]
        public string LeftMessage { get; set; } = "[PLAYER] has left the server.";
        
        [Description("Sets the message for when the round starts.")]
        public string RoundStartedMessage { get; set; } = "Get ready to rumble!";
        
        [Description("Sets the message for when someone triggers a trap.")]
        public string BoobyTrapMessage { get; set; } = "You have activated my trap card!";
    }
}