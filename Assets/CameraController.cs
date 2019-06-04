using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float initialSize;
    public GameObject player;
    Vector2 offset;
    CatController playerCtrl;

    // Use this for initialization
    void Start () {
        initialSize = Camera.main.orthographicSize;
        offset = (Vector2)player.transform.position - (Vector2)transform.position;
        playerCtrl = player.GetComponent<CatController>();
    }
	
	// Update is called once per frame
	void Update () {
        Camera.main.orthographicSize = initialSize * ((10f/4f) / Camera.main.aspect);

        Vector2 newpos = GetMove();
        Vector3 workpos = transform.position;
        workpos.y = newpos.y;
        transform.position = workpos;
	}

    public Vector2 GetMove()
    {
        return new Vector2(0, playerCtrl.GetCameraPosition() - offset.y);
    }
}
