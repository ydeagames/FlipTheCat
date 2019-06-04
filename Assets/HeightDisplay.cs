using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = transform.position.y.ToString("F0") + "m";
	}
}
