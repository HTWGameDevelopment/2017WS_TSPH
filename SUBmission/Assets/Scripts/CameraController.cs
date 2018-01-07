using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float scrollSpeed=0.02f;
	// Use this for initialization
	void Start () {
        scrollSpeed = 0.02f;

    }

	// Update is called once per frame
	void LateUpdate () {
		GameObject.Find("Main Camera").transform.position += new Vector3 (scrollSpeed, 0, 0);

	}
}
