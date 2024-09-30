using System;

namespace Whalepass
{
    [Serializable]
    public class WhalepassEnrollResponse : WhalepassBaseResponse
    {
        public WhalepassPlayer player;

        public WhalepassEnrollResponse(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (succeed)
            {
                player = DeserializeJson<WhalepassPlayer>(baseResponse.responseBody);
            }
        }
    }

    public class WhalepassEnrollRequest
    {
        public string playerId;
        public string gameId;
    }

}
