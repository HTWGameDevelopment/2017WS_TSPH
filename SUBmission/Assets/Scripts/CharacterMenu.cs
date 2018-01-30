using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {


	public Text coins;
	public Text maxHealth;
	public Text maxTorpedo;
	public Text maxAmmo;
	public GameObject SpielerReferance;


	// Use this for initialization
	void Start () {
		coins.text = SpielerReferance.GetComponent<Spieler>().Coins.ToString();
		maxHealth.text = SpielerReferance.GetComponent<Spieler>().Max_Hp.ToString();
		maxTorpedo.text= SpielerReferance.GetComponent<Spieler>().MaxTorpedos.ToString();
		maxAmmo.text= SpielerReferance.GetComponent<Spieler>().MaxGeschossCount.ToString();
	}

	// Update is called once per frame
	void Update () {

	}
}
