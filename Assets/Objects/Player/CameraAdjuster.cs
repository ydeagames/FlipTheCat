using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraAdjuster : NetworkBehaviour
{
    public GameObject player;
    CatController playerCtrl;

    CameraController cameraCtrl;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;

        playerCtrl = player.GetComponent<CatController>();
        cameraCtrl = Camera.main.GetComponent<CameraController>();
        cameraCtrl.offsetY = player.transform.position.y - Camera.main.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        cameraCtrl.targetY = playerCtrl.GetCameraPosition();
    }
}
