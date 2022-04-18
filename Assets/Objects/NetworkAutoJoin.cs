using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Threading.Tasks;
using System.Threading;

public class NetworkAutoJoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_SERVER
        StartCoroutine(RestartClient());
#endif
    }

    IEnumerator RestartClient()
    {
        var networkManager = FindObjectOfType<NetworkManager>();
        networkManager.StopClient();
        yield return null;
        networkManager.StartClient();
    }
}
