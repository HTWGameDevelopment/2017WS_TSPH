using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeschossZähler : MonoBehaviour {
	int spawnedBullets;
	int totalBullets;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "AmmoCount")
        {
            getNumberOfBullets();
            anzeigeUpdaten(getNumberOfBullets());
        }
        else if(this.gameObject.name=="TorpedoCount")
        {
            anzeigeUpdaten(getNumberOfTorpedos());
        }

	}
	string getNumberOfBullets()
	{
		spawnedBullets = 0;
		totalBullets = 0;
        totalBullets= GameObject.Find("Spieler").GetComponent<Spieler>().MaxGeschossCount;
        spawnedBullets = GameObject.Find("Spieler").GetComponent<Spieler>().GeschossCount;
        return (totalBullets - spawnedBullets).ToString();

    }
    string getNumberOfTorpedos()
    {
        return GameObject.Find("Spieler").GetComponent<Spieler>().Torpedos.ToString() + "/" + GameObject.Find("Spieler").GetComponent<Spieler>().MaxTorpedos.ToString();

    }
	public void anzeigeUpdaten(string i)
	{
		this.gameObject.GetComponent<Text>().text = i;
	}
}

