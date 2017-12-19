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





		transform.position = new Vector2 (xNeu, yNeu);
	}
}
