using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Whalepass.Client
{
    internal class WhalepassApiClient : MonoBehaviour
    {
        private static string baseUrl = "http://api.whalepass.gg";
        private static WhalepassApiClient _instance;

        // Start is called before the first frame update
        void Start()
        {
            if(_instance == null)
            {
                _instance = new WhalepassApiClient();
                DontDestroyOnLoad(this);
            }
            {
                Destroy(this);
            }
        }

        public static WhalepassApiClient GetInstance()
        {
            return _instance;
        }

        public void enroll(string username, Action<ApiResponse> onComplete)
        {
            StartCoroutine(GetRequest("", onComplete));
        }

        // Method for sending a GET request
        private IEnumerator GetRequest(string endpoint, Action<ApiResponse> callback)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(baseUrl + endpoint))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    callback(new ApiResponse(null));
                }
                else
                {
                    callback(new ApiResponse(request.downloadHandler.text));
                }
            }
        }

        // Method for sending a POST request
        private IEnumerator PostRequest(string endpoint, string jsonData, Action<ApiResponse> callback)
        {
            using (UnityWebRequest request = new UnityWebRequest(baseUrl + endpoint, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    callback(new ApiResponse(null));
                }
                else
                {
                    callback(new ApiResponse(request.downloadHandler.text));
                }
            }
        }

    }

    public class ApiResponse
    {
        public string response;
        public bool succeed;

        public ApiResponse(string response)
        {
            this.response = response;
            if(response != null)
            {
                succeed = true;
            }
            else
            {
                succeed = false;
            }
        }
    }

}
