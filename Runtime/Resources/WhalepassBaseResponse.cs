using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Whalepass
{
    [SerializeField]
    public class WhalepassBaseResponse
    {
        public bool succeed;
        public string responseBody;
        public string errorBody;

        public WhalepassBaseResponse(bool succeed, string body)
        {
            this.succeed = succeed;
            if(succeed)
            {
                this.responseBody = body;
            } else
            {
                this.errorBody = body;
            }
        }

        public WhalepassBaseResponse(bool succeed, string responseBody, string errorBody)
        {
            this.succeed = succeed;
            this.responseBody = responseBody;
            this.errorBody = errorBody;
        }

        public static T DeserializeJson<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public WhalepassBaseResponse BuildErrorResponse(string error)
        {
            this.succeed = false;
            this.errorBody = error;
            return this;
        }
    }

}
