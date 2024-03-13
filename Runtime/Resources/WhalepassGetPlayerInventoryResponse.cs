using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassGetPlayerInventoryResponse : WhalepassBaseResponse
    {
        public WhalepassPlayerInventory inventory;

        public WhalepassGetPlayerInventoryResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                inventory = DeserializeJson<WhalepassPlayerInventory>(baseResponse.responseBody);
            }
        }
    }

    [SerializeField]
    public class WhalepassPlayerInventory
    {
        public string gameId;
        public string playerId;
        public string externalPlayerId;
        public List<WhalepassPlayerInventoryItem> items;
    }

    [SerializeField]
    public class WhalepassPlayerInventoryItem
    {
        public string rewardId;
        public string battlepassId;
        public string name;
        public float amount;
    }

    [SerializeField]
    public class WhalepassGetPlayerInventoryRequest
    {
        public string playerId;
        public string gameId;
    }
}
