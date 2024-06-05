using UnityEngine;


namespace Whalepass
{
    [CreateAssetMenu(fileName = "WhalepassSdkSettings", menuName = "Whalepass/Api Settings", order = 1)]
    public class WhalepassSdkSettings : ScriptableObject
    {
        public string apiKey;
        public string gameId;
        public string testBattlepassId;
        public static WhalepassSdkSettings settings;

        public static WhalepassSdkSettings LoadSettings()
        {
            if (settings == null)
            {
                settings = Resources.Load<WhalepassSdkSettings>("WhalepassSdkSettings");
            }
            return settings;
        }
    }

}
