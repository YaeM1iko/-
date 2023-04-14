using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace TestPlugin_EXILED2
{
    public class TestPlugin : Plugin<Config>
    {
        public static TestPlugin Instance { get; } = new TestPlugin();
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Player _player;
        private Handlers.Server _server;
        
        private TestPlugin()
        {
            
        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            _player = new Handlers.Player();
            _server = new Handlers.Server();

            Server.WaitingForPlayers += _server.OnWaitingForPlayers;
            Server.RoundStarted += _server.OnRoundStarted;

            /*Player.Left += _player.OnLeft;
            Player.Joined += _player.OnJoined;
            Player.InteractingDoor += _player.OnInteractionDoor;*/
            
            Player.Died += _player.OnDied;
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= _server.OnWaitingForPlayers;
            Server.RoundStarted -= _server.OnRoundStarted;

            /*Player.Left -= _player.OnLeft;
            Player.Joined -= _player.OnJoined;
            Player.InteractingDoor -= _player.OnInteractionDoor;*/

            _player = null;
            _server = null;
        }
    }
}