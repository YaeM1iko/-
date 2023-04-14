using Exiled.API.Features;

namespace TestPlugin_EXILED2.Handlers
{
    public class Server
    {
        public void OnWaitingForPlayers()
        {
            Log.Info("Waiting for players...");
        }

        public void OnRoundStarted()
        {
            Map.Broadcast(6, TestPlugin.Instance.Config.RoundStartedMessage);
        }
    }
}