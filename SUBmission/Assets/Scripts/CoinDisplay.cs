using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour {
	public Text ziffer;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		displayCoins();
	}
	private int getNumberOfCoins()
	{
		return GameObject.Find("Spieler").GetComponent<Spieler>().Coins;
	}
	private void displayCoins()
	{
		ziffer.text=getNumberOfCoins().ToString();
	}
}