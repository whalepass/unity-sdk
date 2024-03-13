using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whalepass;

public class WhalepassConfig
{
    private string apiKey;
    private string gameId;
    private string testBattlepassId;

    public WhalepassConfig(WhalepassSdkSettings settings)
    {
        this.apiKey = settings.apiKey;
        this.gameId = settings.gameId;
        this.testBattlepassId = settings.testBattlepassId;
    }

    public string ApiKey() { return apiKey; }
    public string GameId() { return gameId; }
    public string TestBattlepassId() {  return testBattlepassId; }
}
