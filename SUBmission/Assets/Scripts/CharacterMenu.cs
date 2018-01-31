using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {


	public Text coins;
	public Text maxHealth;
	public Text maxTorpedo;
	public Text maxAmmo;
    public Text HpCost;
    public Text TorpedoCost;
    public Text AmmoCost;
	GameObject data;


	// Use this for initialization
	void Start () {
        data = GameObject.Find("Data");
		coins.text = GameObject.Find("Spieler").GetComponent<Spieler>().Coins.ToString();
		maxHealth.text = data.GetComponent<DataScript>().Max_HpLevel.ToString();
		maxTorpedo.text= data.GetComponent<DataScript>().TorpedosLevel.ToString();
		maxAmmo.text= data.GetComponent<DataScript>().GeschossLevel.ToString();
	}

	// Update is called once per frame
	void Update () {
        coins.text = GameObject.Find("Spieler").GetComponent<Spieler>().Coins.ToString();
        maxHealth.text = data.GetComponent<DataScript>().Max_HpLevel.ToString();
		maxTorpedo.text= data.GetComponent<DataScript>().TorpedosLevel.ToString();
		maxAmmo.text= data.GetComponent<DataScript>().GeschossLevel.ToString();
        HpCost.text = data.GetComponent<DataScript>().costHealth.ToString()+("$");
        TorpedoCost.text = data.GetComponent<DataScript>().costTorpedo.ToString() + ("$");
        AmmoCost.text = data.GetComponent<DataScript>().costAmmo.ToString() + ("$");
    }
}
