using System;
using UnityEngine;
using Whalepass;

[SerializeField]
public class WhalepassGetBattlepassBaseResponse : WhalepassBaseResponse
{
    public WhalepassGetBattlepassBaseResult result;

    public WhalepassGetBattlepassBaseResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
    {
        if (succeed)
        {
            result = DeserializeJson<WhalepassGetBattlepassBaseResult>(responseBody);
        }
    }
}

[SerializeField]
public class WhalepassGetBattlepassBaseResult
{
    public string id;
    public string gameId;
    public string name;
    public bool noTimeLimit;
    public float premiumPrice;
    public DateTime startDate;
    public DateTime endDate;
}
