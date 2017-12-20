using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	float Max_Hp;
	float current_Hp;
	float calcHealth;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void LateUpdate () {
		healthUpdate ();
		transformHealth ();
	}

	public void transformHealth ()
	{
		calcHealth = current_Hp / Max_Hp;
		healthBar.transform.localScale = new Vector3(calcHealth, 1, 1);
	}
	public void healthUpdate()
	{
		Max_Hp = GameObject.Find ("Spieler").GetComponent<Spieler>().Max_Hp;
		current_Hp = GameObject.Find ("Spieler").GetComponent<Spieler> ().current_Hp;
	}
}
