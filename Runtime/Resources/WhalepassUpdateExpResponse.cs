using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassUpdateExpResponse : WhalepassBaseResponse
    {

        public WhalepassUpdateExpResult result;

        public WhalepassUpdateExpResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (succeed)
            {
                result = DeserializeJson<WhalepassUpdateExpResult>(responseBody);
            }
        }
    }

    [SerializeField]
    public class WhalepassUpdateExpResult
    {
        public WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        public List<WhalepassBattlepassLevel> completedLevels;
    }


    [SerializeField]
    public class WhalepassBattlepassLevel
    {
        public string id;
        public int level;
        public long expRequired;
    }

    [SerializeField]
    public class WhalepassPlayerBattlepassProgress
    {
        public string id;
        public string playerId;
        public string battlepassId;
        public long lastCompletedLevel;
        public List<int> completedLevels;
        public List<string> completedChallenges;
    }

    [SerializeField]
    public class WhalepassUpdateExpRequest
    {
        public string playerId;
        public string gameId;
        public long additionalExp;
    }

}
