using System;
using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassCompleteChallengeResponse : WhalepassBaseResponse
    {
        public WhalepassCompleteActionResult result;

        public WhalepassCompleteChallengeResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                result = DeserializeJson<WhalepassCompleteActionResult>(baseResponse.responseBody);
            }
        }
    }

    [SerializeField]
    public class WhalepassCompleteChallengeResult
    {
        public WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        public List<WhalepassBattlepassChallenge> completedChallenges;
    }

    [SerializeField]
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

    [SerializeField]
    public class WhalepassCompleteChallengeRequest
    {
        public string gameId;
        public string playerId;
        public string challengeId;
    }
}
