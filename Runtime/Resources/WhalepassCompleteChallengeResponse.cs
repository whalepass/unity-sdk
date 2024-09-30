using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
    public class WhalepassCompleteChallengeResponse : WhalepassBaseResponse
    {
        public WhalepassCompleteChallengeResult result;

        public WhalepassCompleteChallengeResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                result = DeserializeJson<WhalepassCompleteChallengeResult>(baseResponse.responseBody);
            }
        }
    }

    [Serializable]
    public class WhalepassCompleteChallengeResult
    {
        public WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        public WhalepassBattlepassChallenge completedChallenge;
    }

    [Serializable]
    public class WhalepassBattlepassChallenge
    {
        public string id;
        public string battlepassId;
        public string name;
        public DateTime startDate;
        public DateTime endDate;
        public bool premium;
        public List<WhalepassBattlepassReward> rewards;
    }

    public class WhalepassCompleteChallengeRequest
    {
        public string gameId;
        public string playerId;
        public string challengeId;
    }
}
