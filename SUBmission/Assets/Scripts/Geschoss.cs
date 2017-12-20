using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x+ 5* Time.deltaTime, transform.position.y, 0);
		if (transform.position.x > Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)).x) {
			gameObject.SetActive (false);
		}
	}
}
