using System;

namespace Whalepass
{
    [Serializable]
    public class WhalepassPlayer
    {
        public string id;
        public string externalPlayerId;
        public string gameId;
        public string userId;
        public bool accountConnected;
        public string playerOrigin;
    }

}
