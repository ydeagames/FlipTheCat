using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ObjGenerator : NetworkBehaviour
{
    public int chunk;
    public GameObject item;
    public int amount;
    int top;
    public float marginTop = 60;
    public float marginBottom = 25;
    public int seed = 0;

    List<GameObject> itemObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        top = (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (transform.position.y + marginTop > top + chunk)
        {
            var random = new System.Random(seed + top);

            float left = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
            float right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(item);
                obj.transform.position = new Vector3(
                    (float)random.NextDouble() * (right - left) + left,
                    top + (float)random.NextDouble() * chunk
                    );
                itemObjects.Add(obj);
            }
            top += chunk;

            itemObjects.RemoveAll(obj =>
            {
                if (obj == null)
                    return true;

                if (obj.transform.position.y - transform.position.y < -marginBottom)
                {
                    Destroy(obj);
                    return true;
                }
                return false;
            });
        }
    }
}
