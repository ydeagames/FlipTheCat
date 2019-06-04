using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerator : MonoBehaviour {
    public float chunk;
    public GameObject item;
    public int amount;
    float top;

    // Use this for initialization
    void Start () {
        top = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y > top + chunk)
        {
            float left = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
            float right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(item);
                obj.transform.position = new Vector3(Random.Range(left, right), top + Random.Range(0, chunk));
            }
            top += chunk;
        }
    }
}
