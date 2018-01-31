using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataScript : MonoBehaviour {

    public int overLvl = 0;
	public int Max_HpLevel = 0;
	public int Coins = 0;
	public int GeschossLevel = 0;
	public int TorpedosLevel = 0;
	Button upgradeHealthButton;
    public int costHealth;
	Button upgradeTorpedoButton;
    public int costTorpedo;
    Button upgradeAmmoButton;
    public int costAmmo;
    public string currentSceneName;
    //public float Geschoss_Dmg=10f;
    //public float Torpedo_Dmg = 20f;
    //public float Explosion_Dmg = 50f;
    //public float Explosion_DmgDelay = 0.1f;
    //public float Explosion_DotDmg = 10f;
    //public float Explosion_Tickrate = 0.2f;

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        upgradeAmmoButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxAmmo/UpgradeAmmoButton").GetComponent<Button>();
        upgradeHealthButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxHealth/UpgradeHealthButton").GetComponent<Button>();
        upgradeTorpedoButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxTorpedo/UpgradeTorpedoButton").GetComponent<Button>();
        upgradeAmmoButton.onClick.AddListener(upgradeAmmoButton_Click);
        upgradeHealthButton.onClick.AddListener(upgradeHealthButton_Click);
        upgradeTorpedoButton.onClick.AddListener(upgradeTorpedoButton_Click);
        costHealth = 1;
        costTorpedo = 1;
        costAmmo = 1;
        currentSceneName = getSceneName();
        //overLvl = 0;

    }

	// Update is called once per frame
	void Update () {
        if (getSceneName() != currentSceneName)
        {
            upgradeAmmoButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxAmmo/UpgradeAmmoButton").GetComponent<Button>();
            upgradeHealthButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxHealth/UpgradeHealthButton").GetComponent<Button>();
            upgradeTorpedoButton = GameObject.Find("Ui Camera/HUD/CharacterMenuPanel/MaxTorpedo/UpgradeTorpedoButton").GetComponent<Button>();
            upgradeAmmoButton.onClick.AddListener(upgradeAmmoButton_Click);
            upgradeHealthButton.onClick.AddListener(upgradeHealthButton_Click);
            upgradeTorpedoButton.onClick.AddListener(upgradeTorpedoButton_Click);
            currentSceneName = getSceneName();
        }

        }
    public string getSceneName()
    {
        return SceneManager.GetActiveScene().name;
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
