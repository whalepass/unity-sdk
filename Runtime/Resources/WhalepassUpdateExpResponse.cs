using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    public class WhalepassUpdateExpResponse
    {
        WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        List<WhalepassBattlepassLevel> completedLevels;
    }

    public class WhalepassBattlepassLevel
    {
        string id;
        int level;
        long expRequired;
    }

    public class WhalepassPlayerBattlepassProgress
    {
        string id;
        string playerId;
        string battlepassId;
        long currentExp;
        long lastCompletedLevel;
        List<int> completedLevels;
        List<string> completedChallenges;
    }

}
