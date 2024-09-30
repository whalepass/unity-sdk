using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
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

    [Serializable]
    public class WhalepassPlayerInventory
    {
        public string gameId;
        public string playerId;
        public string externalPlayerId;
        public List<WhalepassPlayerInventoryItem> items;
    }

    [Serializable]
    public class WhalepassPlayerInventoryItem
    {
        public string rewardId;
        public string name;
        public float amount;
        public string mediaUrl;
    }

    public class WhalepassGetPlayerInventoryRequest
    {
        public string playerId;
        public string gameId;
    }
}
