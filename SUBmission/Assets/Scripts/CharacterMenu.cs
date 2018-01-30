using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {


	public Text coins;
	public Text maxHealth;
	public Text maxTorpedo;
	public Text maxAmmo;
	public GameObject data;


	// Use this for initialization
	void Start () {
		coins.text = data.GetComponent<DataScript>().Coins.ToString();
		maxHealth.text = data.GetComponent<DataScript>().Max_HpLevel.ToString();
		maxTorpedo.text= data.GetComponent<DataScript>().TorpedosLevel.ToString();
		maxAmmo.text= data.GetComponent<DataScript>().GeschossLevel.ToString();
	}

	// Update is called once per frame
	void Update () {
		coins.text = data.GetComponent<DataScript>().Coins.ToString();
		maxHealth.text = data.GetComponent<DataScript>().Max_HpLevel.ToString();
		maxTorpedo.text= data.GetComponent<DataScript>().TorpedosLevel.ToString();
		maxAmmo.text= data.GetComponent<DataScript>().GeschossLevel.ToString();
	}
}
