using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    public class WhalepassGetPlayerInventoryResponse
    {
        public bool succeed;
        public WhalepassPlayerInventory inventory;
    }

    public class WhalepassPlayerInventory
    {
        public string gameId;
        public string playerId;
        public string externalPlayerId;
        public List<WhalepassPlayerInventoryItem> items;
    }

    public class WhalepassPlayerInventoryItem
    {
        public string rewardId;
        public string battlepassId;
        public string name;
        public float amount;
    }
}
