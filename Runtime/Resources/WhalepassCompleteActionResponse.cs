using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassCompleteActionResponse : WhalepassBaseResponse
    {

        public WhalepassCompleteActionResult result;

        public WhalepassCompleteActionResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                result = DeserializeJson<WhalepassCompleteActionResult>(baseResponse.responseBody);
            }
        }
    }

    [SerializeField]
    public class WhalepassCompleteActionResult
    {
        public WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        public List<WhalepassBattlepassLevel> completedLevels;
    }

    public class WhalepassCompleteActionRequest
    {
        public string gameId;
        public string actionId;
        public string playerId;
    }

}
