using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataScript : MonoBehaviour {



	public int Max_HpLevel = 0;
	public int Coins = 0;
	public int GeschossLevel = 0;
	public int TorpedosLevel = 0;
	public Button upgradeHealthButton;
	public Button upgradeTorpedoButton;
	public Button upgradeAmmoButton;
	//public float Geschoss_Dmg=10f;
	//public float Torpedo_Dmg = 20f;
	//public float Explosion_Dmg = 50f;
	//public float Explosion_DmgDelay = 0.1f;
	//public float Explosion_DotDmg = 10f;
	//public float Explosion_Tickrate = 0.2f;



	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

    }

	// Update is called once per frame
	void Update () {
		upgradeAmmoButton.onClick.AddListener (upgradeAmmoButton_Click);
		upgradeHealthButton.onClick.AddListener (upgradeHealthButton_Click);
		upgradeTorpedoButton.onClick.AddListener (upgradeTorpedoButton_Click);
	}


	public void  upgradeHealthButton_Click(){
		Max_HpLevel ++;
	}
	public void  upgradeTorpedoButton_Click(){
		TorpedosLevel ++;
	}
	public void  upgradeAmmoButton_Click(){
		GeschossLevel ++;
	}

}
