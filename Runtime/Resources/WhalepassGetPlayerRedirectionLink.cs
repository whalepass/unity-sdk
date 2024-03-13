using UnityEngine;

namespace Whalepass
{
    [SerializeField]
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

    [SerializeField]
    public class WhalepassPlayerRedirectionLink
    {
        public string redirectionLink;
    }

    [SerializeField]
    public class WhalepassGetPlayerRedirectionLinkRequest
    {
        public string playerId;
        public string gameId;
    }

}
