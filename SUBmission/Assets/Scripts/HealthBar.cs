using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public GameObject healthBar;
	float Max_Hp;
	float Current_Hp;
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
		calcHealth = Current_Hp / Max_Hp;
		healthBar.transform.localScale = new Vector3(calcHealth, 1, 1);
	}
	public void healthUpdate()
	{
		Max_Hp = 100f + (10 * GameObject.Find ("Data").GetComponent<DataScript>().Max_HpLevel);
		Current_Hp = GameObject.Find ("Spieler").GetComponent<Spieler>().Current_Hp;
	}
}
