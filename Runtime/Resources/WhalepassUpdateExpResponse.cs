using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
    public class WhalepassUpdateExpResponse : WhalepassBaseResponse
    {

        public WhalepassUpdateExpResult result;

        public WhalepassUpdateExpResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                result = DeserializeJson<WhalepassUpdateExpResult>(baseResponse.responseBody);
            }
        }
    }

    [Serializable]
    public class WhalepassUpdateExpResult
    {
        public WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        public List<WhalepassBattlepassLevel> completedLevels;
    }

    [Serializable]
    public class WhalepassBattlepassLevel
    {
        public string id;
        public string battlepassId;
        public int level;
        public long expRequired;
        public bool status;
        public List<WhalepassBattlepassReward> freeTierRewards;
        public List<WhalepassBattlepassReward> premiumTierRewards;
    }

    [Serializable]
    public class WhalepassPlayerBattlepassProgress
    {
        public string id;
        public string playerId;
        public string battlepassId;
        public long currentExp;
        public long lastCompletedLevel;
        public List<int> completedLevels;
        public List<string> completedChallenges;
    }

    public class WhalepassUpdateExpRequest
    {
        public string playerId;
        public string gameId;
        public long additionalExp;
    }

}
