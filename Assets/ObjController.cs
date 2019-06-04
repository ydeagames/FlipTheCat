using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    GameObject player;
    public int hpAdd;
    public AudioClip se;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - player.transform.position.y < -25f)
            Destroy(gameObject);

        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p2 - p1;
        float d = dir.magnitude;
        float r1 = .5f;
        float r2 = 1f;

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().hp += hpAdd;
            player.GetComponent<AudioSource>().PlayOneShot(se);

            Destroy(gameObject);
        }
    }
}
