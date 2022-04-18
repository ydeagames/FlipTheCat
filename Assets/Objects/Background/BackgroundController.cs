using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public float gridsize;
    Camera cameraObj;
    Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        cameraObj = Camera.main;
        cameraOffset = transform.position - cameraObj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float moveY = cameraObj.GetComponent<CameraController>().GetTargetY();
        Vector3 vec = new Vector3(
            Mathf.Repeat(gridsize / 2, gridsize) - gridsize / 2,
            Mathf.Repeat(moveY + gridsize / 2, gridsize) - gridsize / 2);
        Vector3 pos = cameraObj.transform.position + cameraOffset - vec;
        Vector3 workpos = transform.position;
        workpos.y = pos.y;
        transform.position = workpos;
	}
}
