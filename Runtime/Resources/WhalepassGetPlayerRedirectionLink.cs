using System;

namespace Whalepass
{
    [Serializable]
    public class WhalepassGetPlayerRedirectionLink : WhalepassBaseResponse
    {
        public WhalepassPlayerRedirectionLink link;

        public WhalepassGetPlayerRedirectionLink(WhalepassBaseResponse baseResponse) : base(baseResponse.succeed, baseResponse.responseBody, baseResponse.errorBody)
        {
            if (baseResponse.succeed)
            {
                link = DeserializeJson<WhalepassPlayerRedirectionLink>(baseResponse.responseBody);
            }
        }
    }

    [Serializable]
    public class WhalepassPlayerRedirectionLink
    {
        public string redirectionLink;
    }

    public class WhalepassGetPlayerRedirectionLinkRequest
    {
        public string playerId;
        public string gameId;
    }

}
