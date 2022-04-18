using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public GameObject player;
    CatController playerCtrl;

    CameraController cameraCtrl;

    // Use this for initialization
    void Start()
    {
        playerCtrl = player.GetComponent<CatController>();
        cameraCtrl = Camera.main.GetComponent<CameraController>();
        cameraCtrl.offsetY = player.transform.position.y - Camera.main.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraCtrl.targetY = playerCtrl.GetCameraPosition();
    }
}
