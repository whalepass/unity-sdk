using System;
using UnityEngine;
using Whalepass.Client;

namespace Whalepass
{
    public class WhalepassSdkManager
    {
        private static WhalepassPlayer currentPlayer;

        public static void enroll(string externalPlayerId, Action<WhalepassEnrollResponse> onComplete)
        {
            if (!ValidateSdkSettings())
            {
                onComplete.Invoke(new WhalepassEnrollResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));
                return;
            }

            Action<WhalepassEnrollResponse> wrappedOnComplete = (response) =>
            {
                // Here, you can intercept the result and do something with it
                // For example, log the response or perform additional processing
                Debug.Log("Intercepted onComplete with response: " + response);
                if (response.succeed)
                    currentPlayer = response.player;

                // Then, call the original onComplete callback with the response
                onComplete?.Invoke(response);
            };

            var request = new WhalepassEnrollRequest();
            request.playerId = externalPlayerId;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;
            WhalepassApiClient.Instance.enroll(request, onComplete);
        }

        public static void updateExp(string externalPlayerId, long additionalExp, Action<WhalepassUpdateExpResponse> onComplete)
        {
            if (!ValidateSdkSettings())
            {
                Debug.Log("Sdk Settings Failed");
                onComplete.Invoke(new WhalepassUpdateExpResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));
                return;
            }

            var request = new WhalepassUpdateExpRequest();
            request.playerId = externalPlayerId;
            request.additionalExp = additionalExp;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.updateExp(request, onComplete);
        }

        public static void updateExp(long additionalExp, Action<WhalepassUpdateExpResponse> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassUpdateExpResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));


            if (!ValidateCurrentPlayer())
                onComplete.Invoke(new WhalepassUpdateExpResponse(new WhalepassBaseResponse(false, null, "Current player is not initialized!")));

            updateExp(currentPlayer.externalPlayerId, additionalExp, onComplete);
        }

        public static void completeChallenge(string externalPlayerId, string challengeIdentifier, Action<WhalepassCompleteChallengeResponse> onComplete)
        {
            Debug.Log("Complete Challenge");
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassCompleteChallengeResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassCompleteChallengeRequest();
            request.playerId = externalPlayerId;
            request.challengeId = challengeIdentifier;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.completeChallenge(request, onComplete);
        }

        public static void completeAction(string externalPlayerId, string actionIdentifier, Action<WhalepassCompleteActionResponse> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassCompleteActionResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassCompleteActionRequest();
            request.playerId = externalPlayerId;
            request.actionId = actionIdentifier;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.completeAction(request, onComplete);
        }

        public static void getPlayerBaseProgress(string externalPlayerId, Action<WhalepassGetPlayerBaseProgressResponse> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassGetPlayerBaseProgressResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassGetPlayerBaseProgressRequest();
            request.playerId = externalPlayerId;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.getPlayerBaseProgress(request, onComplete);
        }

        public static void getPlayerInventory(string externalPlayerId, Action<WhalepassGetPlayerInventoryResponse> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassGetPlayerInventoryResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassGetPlayerInventoryRequest();
            request.playerId = externalPlayerId;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.getPlayerInventory(request, onComplete);
        }

        public static void getPlayerRedirectionLink(string externalPlayerId, Action<WhalepassGetPlayerRedirectionLink> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassGetPlayerRedirectionLink(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassGetPlayerRedirectionLinkRequest();
            request.playerId = externalPlayerId;
            request.gameId = WhalepassApiClient.Instance.Settings.gameId;

            WhalepassApiClient.Instance.getPlayerRedirectionLink(request, onComplete);
        }

        public static void getBattlepass(string battlepassId, bool includeLevels, bool includeChallenges, Action<WhalepassGetBattlepassResponse> onComplete)
        {
            if (!ValidateSdkSettings())
                onComplete.Invoke(new WhalepassGetBattlepassResponse(new WhalepassBaseResponse(false, null, "Sdk Settings is not initialized!")));

            var request = new WhalepassGetBattlepassRequest();
            request.includeLevels = includeLevels;
            request.includeChallenges = includeChallenges;
            request.battlepassId = battlepassId;

            WhalepassApiClient.Instance.getBattlepass(request, onComplete);
        }

        private static void Log(string log)
        {
            Debug.Log(log);
        }

        private static bool ValidateCurrentPlayer()
        {
            if (currentPlayer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private static bool ValidateSdkSettings()
        {
            if (WhalepassApiClient.Instance.Settings == null)
                return false;

            if (WhalepassApiClient.Instance.Settings.apiKey == null)
                return false;

            if (WhalepassApiClient.Instance.Settings.gameId == null)
                return false;

            return true;
        }

    }
}
