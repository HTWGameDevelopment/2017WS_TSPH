using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeschossZähler : MonoBehaviour {
	int spawnedBullets;
	int totalBullets;
	public Text ziffer;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		getNumberofBullets();
		anzeigeUpdaten();

	}
	public void getNumberofBullets()
	{
		spawnedBullets = 0;
		totalBullets = 0;
		foreach (GameObject b in GameObject.Find("Spieler").GetComponent<Spieler>().geschoss)
		{
			totalBullets++;
			if (b.activeSelf)
			{
				spawnedBullets++;
			}
		}
	}
	public void anzeigeUpdaten()
	{
		ziffer.text = (totalBullets - spawnedBullets).ToString();
	}
}

