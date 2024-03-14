
# Whalepass Unity SDK


## Installation

To be able to install the SDK, you can use this github repository and Unity Package Manager

- Go to Unity -> Window -> Package Manager
- Click + button on upper left of Package Manager
- Choose Add package from git URL...
- Enter https://github.com/whalepass/unity-sdk.git

  
## Settings

- After adding the SDK you should see Whalepass menu in upper panel of Unity
- Click Whalepass -> Api Settings
- Enter required information (You can find them from the dashboard.whalepas.gg)
- Click save then exit.

  
## Usage/Examples

Enrolling Player

```
WhalepassSdkManager.enroll("testPlayer123444", response =>
        {
            Debug.Log(response.succeed);
        });
```

Updating Exp of Player (HARD CODED)

```
WhalepassSdkManager.updateExp("testPlayer123444", 100, response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Updating Exp of Player via Game Action

```
WhalepassSdkManager.completeAction("testPlayer123444", "TEST_ACTION", response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Completing Challenge

```
WhalepassSdkManager.completeChallenge("testPlayer123444", "ed18e60a-015b-4453-a9b6-be668946a1c2", response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Getting Player's Inventory

```
WhalepassSdkManager.getPlayerInventory("testPlayer123444", response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Getting Player's Base Response

```
WhalepassSdkManager.getPlayerBaseProgress("testPlayer123444", response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Getting Player's Redirection Link for app.whalepass.gg

```
WhalepassSdkManager.getPlayerRedirectionLink("testPlayer123444", response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```

Getting Battlepass

```
WhalepassSdkManager.getBattlepass("2f6c3561-707d-4c48-9397-e5df0f555df0", false, false, response =>
        {
            Debug.Log(response.succeed);
            Debug.Log(response.responseBody);
        });
```
