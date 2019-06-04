using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public float gridsize;
    GameObject cameraObj;
    Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        cameraObj = GameObject.Find("Camera");
        cameraOffset = transform.position - cameraObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 move = cameraObj.GetComponent<CameraController>().GetMove();
        Vector3 vec = new Vector3(
            Mathf.Repeat(move.x + gridsize / 2, gridsize) - gridsize / 2,
            Mathf.Repeat(move.y + gridsize / 2, gridsize) - gridsize / 2);
        Vector3 pos = cameraObj.transform.position + cameraOffset - vec;
        Vector3 workpos = transform.position;
        workpos.y = pos.y;
        transform.position = workpos;
	}
}
