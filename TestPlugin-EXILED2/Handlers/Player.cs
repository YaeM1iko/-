using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using TestPlugin_EXILED2.Features;
using UnityEngine;

namespace TestPlugin_EXILED2.Handlers
{
    public class Player
    {
        /*public void OnLeft(LeftEventArgs e)
        {
            var message = TestPlugin.Instance.Config.LeftMessage.Replace("[PLAYER]", e.Player.Nickname);
            Map.Broadcast(6, $"{e.Player} has left the server.");
        }

        public void OnJoined(JoinedEventArgs e)
        {
            var message = TestPlugin.Instance.Config.LeftMessage.Replace("[PLAYER]", e.Player.Nickname);
            Map.Broadcast(6, $"{e.Player} has joined the server!");
        }

        public void OnInteractionDoor(InteractingDoorEventArgs e)
        {
            if (!e.IsAllowed)
            {
                e.Player.Broadcast(3, TestPlugin.Instance.Config.BoobyTrapMessage);
                e.Player.Kill(DamageType.Poison);
            }
        }*/

        public void OnDied(DiedEventArgs e)
        {
            var ply = e.Player;
            SCP1956Controller.DeleteSCP1956(ply);
        }
    }
}