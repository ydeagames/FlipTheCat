using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float targetY;
    public float offsetY;

    float initialSize;

    // Use this for initialization
    void Start()
    {
        initialSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = initialSize * ((10f / 4f) / Camera.main.aspect);

        float targetY = GetTargetY();
        Vector3 workpos = Camera.main.transform.position;
        workpos.y = targetY;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, workpos, .9f);
    }

    public float GetTargetY()
    {
        return targetY - offsetY;
    }
}
