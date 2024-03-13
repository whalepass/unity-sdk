using UnityEngine;
using Whalepass.Client;

public class WhalepassInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var result = WhalepassApiClient.Instance;
    }

}
