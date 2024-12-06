using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
    public class WhalepassGetPlayerProgressResponse : WhalepassBaseResponse
    {
        public WhalepassGetPlayerProgressResult result;

        public WhalepassGetPlayerProgressResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                result = DeserializeJson<WhalepassGetPlayerProgressResult>(baseResponse.responseBody);
            }
        }
    }

    [Serializable]
    public class WhalepassGetPlayerProgressResult
    {
        public WhalepassPlayer player;
        public WhalepassPlayerBattlepassProgressResult battlepassProgress;
    }

    [Serializable]
    public class WhalepassPlayerBattlepassProgressResult
    {
        public string battlepassId;
        public int currentExp;
        public int lastCompletedLevel;
        public List<WhalepassPlayerBattlepassLevelProgress> levels;
        public List<WhalepassPlayerBattlepassChallengeProgress> challenges;
    }

    [Serializable]
    public class WhalepassPlayerBattlepassChallengeProgress
    {
        public string id;
        public string battlepassId;
        public string name;
        public DateTime startDate;
        public DateTime endDate;
        public Boolean active;
        public Boolean premium;
        public Boolean completed;
        public List<WhalepassBattlepassReward> rewards;
    }


    [Serializable]
    public class WhalepassPlayerBattlepassLevelProgress
    {
        public string id;
        public string battlepassId;
        public int level;
        public int expRequired;
        public Boolean active;
        public Boolean completed;
        public List<WhalepassBattlepassReward> freeTierRewards;
        public List<WhalepassBattlepassReward> premiumTierRewards;
    }

}
