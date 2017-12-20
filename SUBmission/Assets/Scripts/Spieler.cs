﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour {


	public float Max_Hp = 100f;
	public float Current_Hp = 0f;
	public int Coins = 0;
	// Use this for initialization
	void Start () {
		Current_Hp = Max_Hp;
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

		if (xNeu < p.x + -1.5f){
			Current_Hp = 0f;
			xNeu =p.x+1.5f;
		}

		if (xNeu > q.x-1.5f){
			xNeu =q.x-1.5f;
		}

		if (Input.GetButtonDown ("Fire1")) {
			for (int i = 0; i < 3; i++) {
				if (!geschoss [i].activeSelf) {
					geschoss [i].transform.position = new Vector3 (this.transform.position.x + 2f, this.transform.position.y, 0);
					geschoss [i].SetActive (true);
					break;
				}
			}
		}



		transform.position = new Vector2 (xNeu, yNeu);
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		

	    if (coll.gameObject.tag == "Environment")
		{
			transform.position =  Camera.main.ScreenToWorldPoint (new Vector3 (400,300, 0));
			HealthChange(10);
		}

	}


	void HealthChange(int schaden){
		Current_Hp = Current_Hp-schaden;
	}

}
