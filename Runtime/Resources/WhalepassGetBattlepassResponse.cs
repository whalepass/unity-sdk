using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
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

    [SerializeField]
    public class WhalepassBattlepass
    {
        public string id;
        public string name;
        public List<WhalepassBattlepassChallenge> challenges;
        public List<WhalepassBattlepassLevel> level;
    }

    [SerializeField]
    public class WhalepassGetBattlepassRequest
    {
        public string battlepassId;
        public bool includeLevels;
        public bool includeChallenges;
    }
}
