using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    public class WhalepassCompleteChallengeResponse
    {
        WhalepassPlayerBattlepassProgress playerBattlepassProgress;
        List<WhalepassBattlepassChallenge> completedChallenges;
    }

    public class WhalepassBattlepassChallenge
    {
        string id;
        string name;
        bool premium;
    }

}
