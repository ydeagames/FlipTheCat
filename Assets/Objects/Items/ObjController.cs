using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public int hpAdd;
    public AudioClip se;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().hp += hpAdd;
        other.gameObject.GetComponent<AudioSource>().PlayOneShot(se);
        Destroy(gameObject);
    }
}
