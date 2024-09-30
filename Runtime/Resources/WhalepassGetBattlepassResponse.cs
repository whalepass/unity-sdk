using System;
using System.Collections.Generic;

namespace Whalepass
{
    [Serializable]
    public class WhalepassGetBattlepassResponse : WhalepassBaseResponse
    {

        public WhalepassBattlepass battlepass;

        public WhalepassGetBattlepassResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                battlepass = DeserializeJson<WhalepassBattlepass>(baseResponse.responseBody);
            }
        }
    }

    [Serializable]
    public class WhalepassBattlepass
    {
        public string id;
        public string name;
        public List<WhalepassBattlepassChallenge> challenges;
        public List<WhalepassBattlepassLevel> levels;
    }

    public class WhalepassGetBattlepassRequest
    {
        public string battlepassId;
        public bool includeLevels;
        public bool includeChallenges;
    }
}
