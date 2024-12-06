using System;

namespace Whalepass
{
    [Serializable]
    public class WhalepassGetPlayerBaseProgressResponse : WhalepassBaseResponse
    {
        public WhalepassPlayerBaseProgress result;

        public WhalepassGetPlayerBaseProgressResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            result = DeserializeJson<WhalepassPlayerBaseProgress>(baseResponse.responseBody);
        }
    }

    [Serializable]
    public class WhalepassPlayerBaseProgress
    {
        public string playerId;
        public string externalPlayerId;
        public string gameId;
        public string battlepassId;
        public long currentExp;
        public long lastCompletedLevel;
        public long expRequiredForLastLevel;
        public long expRequiredForNextLevel;
    }

    public class WhalepassGetPlayerBaseProgressRequest
    {
        public string playerId;
        public string gameId;
    }

}
