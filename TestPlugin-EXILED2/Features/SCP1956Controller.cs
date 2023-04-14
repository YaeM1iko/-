using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using PlayerRoles;
using UnityEngine;

namespace TestPlugin_EXILED2.Features
{
    public static class SCP1956Controller
    {
        private static readonly Dictionary<Player, int> _players = new Dictionary<Player, int>();

        public static bool IsThereSCP(Player player) => _players.ContainsKey(player);

        public static void SetSCP1956(Player ply, out string response)
        {
            _players.Add(ply, 0);
            
            ply.Role.Set(RoleTypeId.ClassD);
            ply.Scale = new Vector3(1.5f, 0.7f, 1.5f);
            ply.Health = 500;
            ply.Broadcast(5, "Поздравляю вы SCP1956!");
            
            response = "Команда работаит!";
        }

        public static void DeleteSCP1956(Player ply)
        {
            _players.Remove(ply);
            ply.Scale = new Vector3(1f, 1f, 1f);
        }

        public static bool StartApart(Player ply, out string response)
        {
            if (ply.CurrentItem == null)
            {
                response = "ДЕржи его в руках СУКА!";
                return false;
            }
            
            _players[ply] += (int)ply.CurrentItem.Type + 1;
            ply.CurrentItem.Destroy();
            response = "Команда работаит!";
            return true;
        }

        public static bool StartCreate(Player ply, out string response)
        {
            var mainPoints = _players[ply];
            if (mainPoints <= 0)
            {
                response = "мало деняг!";
                return false;
            }

            var itemTypes = (ItemType[])Enum.GetValues(typeof(ItemType));
            var items = new List<ItemType>();
            while (mainPoints > 0)
            {
                var randomItem = itemTypes[UnityEngine.Random.Range(0, mainPoints > itemTypes.Length 
                    ? itemTypes.Length : mainPoints)];
                items.Add(randomItem);
                mainPoints -= (int)randomItem + 1;
            }

            _players[ply] = 0;

            foreach (var item in items)
                Pickup.CreateAndSpawn(item, ply.Position, default);

            response = "Команда работаит!";
            return true;
        }

        public static int GetPoints(Player ply) => _players[ply];
    }
}