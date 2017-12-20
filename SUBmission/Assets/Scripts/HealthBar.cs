using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	public GameObject healthBar;
	public float Max_Hp = 100f;
	public float current_Hp = 0f;
	float clacHealth=0f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void LateUpdate () {
		transformHealth ();
	}
	public void transformHealth ()
	{
		clacHealth = current_Hp / Max_Hp;
		healthBar.transform.localScale = new Vector3(clacHealth, 1, 1);
	}
}
