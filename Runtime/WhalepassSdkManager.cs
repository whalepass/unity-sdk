using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Whalepass.Client;

namespace Whalepass
{
    public class WhalepassSdkManager
    {
        private static WhalepassPlayer currentPlayer;

        public static void enroll(string externalPlayerId, Action<WhalepassEnrollResponse> onComplete)
        {
            WhalepassApiClient.GetInstance().enroll(externalPlayerId, response =>
            {
                
            });
        }

        public static void updateExp(string externalPlayerId, long additionalExp, Action<WhalepassUpdateExpResponse> onComplete)
        {

        }

        public static void completeChallenge(string externalPlayerId, string challengeIdentifier, Action<WhalepassCompleteChallengeResponse> onComplete)
        {

        }

        public static void completeAction(string externalPlayerId, string actionIdentifier, Action<WhalepassCompleteActionResponse> onComplete)
        {

        }

        public static void getPlayerProgress(string externalPlayerId, Action<WhalepassGetPlayerProgressResponse> onComplete)
        {

        }

        public static void getPlayersProgress(List<string> playerIds, Action<WhalepassGetPlayersProgressResponse> onComplete)
        {

        }

        public static void getPlayerInventory(string externalPlayerId, Action<WhalepassGetPlayerInventoryResponse> onComplete)
        {

        }

        public static void getPlayerRedirectionLink(string externalPlayerId, Action<WhalepassGetPlayerRedirectionLink> onComplete)
        {

        }

    }
}
