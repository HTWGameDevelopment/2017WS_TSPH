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
    public int costHealth;
	public Button upgradeTorpedoButton;
    public int costTorpedo;
    public Button upgradeAmmoButton;
    public int costAmmo;
    //public float Geschoss_Dmg=10f;
    //public float Torpedo_Dmg = 20f;
    //public float Explosion_Dmg = 50f;
    //public float Explosion_DmgDelay = 0.1f;
    //public float Explosion_DotDmg = 10f;
    //public float Explosion_Tickrate = 0.2f;



    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        upgradeAmmoButton.onClick.AddListener(upgradeAmmoButton_Click);
        upgradeHealthButton.onClick.AddListener(upgradeHealthButton_Click);
        upgradeTorpedoButton.onClick.AddListener(upgradeTorpedoButton_Click);
        costHealth = 1;
        costTorpedo = 1;
        costAmmo = 1;

    }

	// Update is called once per frame
	void Update () {
	}

    public void upgradeHealthButton_Click()
    {
        if (GameObject.Find("Spieler").GetComponent<Spieler>().Coins >= costHealth)
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().Coins -= costHealth;
            Max_HpLevel++;
            costHealth++;
        }
    }
	public void  upgradeTorpedoButton_Click(){
        if (GameObject.Find("Spieler").GetComponent<Spieler>().Coins >= costTorpedo)
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().Coins -= costTorpedo;
            TorpedosLevel++;
            costTorpedo++;
        }

    }
	public void  upgradeAmmoButton_Click(){
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Coins >= costAmmo)
            {
                GameObject.Find("Spieler").GetComponent<Spieler>().Coins -= costAmmo;
                GeschossLevel++;
                costAmmo++;
            }
	}

}
