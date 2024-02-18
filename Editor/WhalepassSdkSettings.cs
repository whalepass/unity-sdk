using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Whalepass
{
    [CreateAssetMenu(fileName = "WhalepassSdkSettings", menuName = "Whalepass/Api Settings", order = 1)]
    public class WhalepassSdkSettings : ScriptableObject
    {
        public string apiKey;
        public string gameId;
        public string testBattlepassId;
    }

}
