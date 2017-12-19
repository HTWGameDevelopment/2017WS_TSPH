using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	float eingabeFaktor = 8;
	public GameObject[] geschoss = new GameObject[3];

	//  Update is called once per frame
	void Update () {

	

		//Eingabe speichern
		float xEingabe = Input.GetAxis ("Horizontal");
		float yEingabe = Input.GetAxis ("Vertical");

		//Neue Position bestimmen

		float xNeu = transform.position.x + xEingabe * eingabeFaktor* Time.deltaTime ;
		float yNeu = transform.position.y + yEingabe * eingabeFaktor* Time.deltaTime ;

		if (yNeu < -4f) {
			yNeu = -4f;
		} 

		if (yNeu > 4f) {
			yNeu = 4f;
		}

		Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector3 q = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));

		if (xNeu < p.x + 1.5f){
			xNeu =p.x+1.5f;
		}

		if (xNeu > q.x-1.5f){
			xNeu =q.x-1.5f;
		}



		transform.position = new Vector2 (xNeu, yNeu);
	}
}
