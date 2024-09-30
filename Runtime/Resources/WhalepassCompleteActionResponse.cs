using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
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

    [Serializable]
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
