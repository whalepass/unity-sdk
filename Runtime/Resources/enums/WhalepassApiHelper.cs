using System;

public class WhalepassApiHelper
{
    private static readonly string BaseUrl = "https://api.whalepass.gg/";

    public static WhalepassRequest GetUri(WhalepassApiEndpoint endpoint)
    {
        switch (endpoint)
        {
            case WhalepassApiEndpoint.ENROLL:
                return new WhalepassRequest(BaseUrl + "enrollments", "POST");
            case WhalepassApiEndpoint.UPDATE_EXP:
                return new WhalepassRequest(BaseUrl + "players/{0}/progress/exp", "POST");
            case WhalepassApiEndpoint.COMPLETE_ACTION:
                return new WhalepassRequest(BaseUrl + "players/{0}/progress/action", "POST");
            case WhalepassApiEndpoint.COMPLETE_CHALLENGE:
                return new WhalepassRequest(BaseUrl + "players/{0}/progress/challenge", "POST");
            case WhalepassApiEndpoint.GET_PLAYER_INVENTORY:
                return new WhalepassRequest(BaseUrl + "players/{0}/inventory?gameId={1}", "GET");
            case WhalepassApiEndpoint.GET_PLAYER_PROGRESS_BASE:
                return new WhalepassRequest(BaseUrl + "players/{0}/progress/base?gameId={1}", "GET");
            case WhalepassApiEndpoint.GET_REDIRECTION_LINK:
                return new WhalepassRequest(BaseUrl + "players/{0}/redirect?gameId={1}", "GET");
            case WhalepassApiEndpoint.GET_BATTLEPASS:
                return new WhalepassRequest(BaseUrl + "battlepass/{0}?includeLevels={1}&includeChallenges={2}", "GET");
            case WhalepassApiEndpoint.GET_BATTLEPASS_BASE:
                return new WhalepassRequest(BaseUrl + "battlepass/base?gameId={0}", "GET");
            case WhalepassApiEndpoint.GET_PLAYER_PROGRESS:
                return new WhalepassRequest(BaseUrl + "players/{0}/progress?gameId={1}", "GET");
            // Add other cases as needed
            default:
                throw new ArgumentOutOfRangeException(nameof(endpoint), $"Not expected endpoint value: {endpoint}");
        }
    }


}

public class WhalepassRequest
{
    public string url;
    public string method;

    public WhalepassRequest(string url, string method)
    {
        this.url = url;
        this.method = method;
    }
}
