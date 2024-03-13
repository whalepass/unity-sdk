using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Whalepass.Client
{
    internal class WhalepassApiClient : MonoBehaviour
    {
        private static WhalepassApiClient _instance;
        private static WhalepassSdkSettings _settings;

        public WhalepassSdkSettings Settings { get { return _settings; } }

        public static WhalepassApiClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Find existing instance
                    _instance = FindObjectOfType<WhalepassApiClient>();
                    if (_instance == null)
                    {
                        // Create new instance if one doesn't already exist
                        GameObject apiManagerObj = new GameObject("ApiManager");
                        _instance = apiManagerObj.AddComponent<WhalepassApiClient>();
                        _settings = AssetDatabase.LoadAssetAtPath<WhalepassSdkSettings>("Assets/Editor/WhalepassSdkSettings.asset");
                    }
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }

        public void enroll(WhalepassEnrollRequest request, Action<WhalepassEnrollResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.ENROLL);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassEnrollResponse(response));
            }));
        }

        public void updateExp(WhalepassUpdateExpRequest request, Action<WhalepassUpdateExpResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.UPDATE_EXP);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassUpdateExpResponse(response));
            }));
        }

        internal void completeAction(WhalepassCompleteActionRequest request, Action<WhalepassCompleteActionResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.COMPLETE_ACTION);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassCompleteActionResponse(response));
            }));
        }

        internal void completeChallenge(WhalepassCompleteChallengeRequest request, Action<WhalepassCompleteChallengeResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.COMPLETE_CHALLENGE);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassCompleteChallengeResponse(response));
            }));
        }

        internal void getPlayerInventory(WhalepassGetPlayerInventoryRequest request, Action<WhalepassGetPlayerInventoryResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.GET_PLAYER_INVENTORY);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId, request.gameId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassGetPlayerInventoryResponse(response));
            }));
        }

        internal void getPlayerBaseProgress(WhalepassGetPlayerBaseProgressRequest request, Action<WhalepassGetPlayerBaseProgressResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.GET_PLAYER_PROGRESS_BASE);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId, request.gameId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassGetPlayerBaseProgressResponse(response));
            }));
        }

        internal void getPlayerRedirectionLink(WhalepassGetPlayerRedirectionLinkRequest request, Action<WhalepassGetPlayerRedirectionLink> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.GET_REDIRECTION_LINK);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.playerId, request.gameId);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassGetPlayerRedirectionLink(response));
            }));
        }

        internal void getBattlepass(WhalepassGetBattlepassRequest request, Action<WhalepassGetBattlepassResponse> onComplete)
        {
            var whalepassRequest = WhalepassApiHelper.GetUri(WhalepassApiEndpoint.GET_BATTLEPASS);
            whalepassRequest.url = String.Format(whalepassRequest.url, request.battlepassId, request.includeLevels, request.includeChallenges);
            var webRequest = BuildUnityWebRequest(whalepassRequest, JsonUtility.ToJson(request), new Dictionary<string, string> { { "X-Battlepass-Id", _settings.testBattlepassId }, { "X-Api-Key", _settings.apiKey } });
            StartCoroutine(SendRequest(webRequest, response =>
            {
                onComplete.Invoke(new WhalepassGetBattlepassResponse(response));
            }));
        }

        private static UnityWebRequest BuildUnityWebRequest(WhalepassRequest whalepassRequest, string bodyJson, Dictionary<string, string> headers)
        {
            UnityWebRequest request;

            if (whalepassRequest.method.Equals("GET"))
            {
                request = UnityWebRequest.Get(whalepassRequest.url);
            }
            else
            {
                request = new UnityWebRequest(whalepassRequest.url, whalepassRequest.method);

                if (!string.IsNullOrEmpty(bodyJson))
                {
                    byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJson);
                    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                }

                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            }

            // Set content type to JSON if we have a body, otherwise it can be adjusted as needed.
            if (!string.IsNullOrEmpty(bodyJson) && (headers == null || !headers.ContainsKey("Content-Type")))
            {
                request.SetRequestHeader("Content-Type", "application/json");
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);
                }
            }

            return request;
        }

        // Method for sending a GET request
        private IEnumerator SendRequest(UnityWebRequest builtRequest, Action<WhalepassBaseResponse> callback)
        {
            using (UnityWebRequest request = builtRequest)
            {
                if (!request.method.Equals("GET"))
                {
                    request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                }

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    callback(new WhalepassBaseResponse(false, request.error));
                }
                else
                {
                    callback(new WhalepassBaseResponse(true, request.downloadHandler.text));
                }
            }
        }

    }

}
