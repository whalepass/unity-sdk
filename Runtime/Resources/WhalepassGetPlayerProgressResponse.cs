using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassGetPlayerBaseProgressResponse : WhalepassBaseResponse
    {
        public WhalepassPlayerBaseProgress result;

        public WhalepassGetPlayerBaseProgressResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            result = DeserializeJson<WhalepassPlayerBaseProgress>(baseResponse.responseBody);
        }
    }

    [SerializeField]
    public class WhalepassPlayerBaseProgress
    {
        public string playerId;
        public string externalPlayerId;
        public string gameId;
        public string battlepassId;
        public long currentExp;
        public long lastCompletedLevel;
    }

    [SerializeField]
    public class WhalepassGetPlayerBaseProgressRequest
    {
        public string playerId;
        public string gameId;
    }

}
