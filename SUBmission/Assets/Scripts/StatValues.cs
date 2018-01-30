using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatValues : MonoBehaviour {
    //SielerStats
    public int money = 0;
    //Position
    public int LevelIteration = 0;
    public int level;
    //UpgradeLvl
    public int Geschoss_Dmg;
    public int Geschoss_Count;
    public int Geschoss_Speed;
    public int Torpedo_Reserve;
    public int Torpedo_Dmg;
    public int Torpedo_Regeneration;
    public int Torpedo_Dot;
    public int Torpedo_Tickrate;
    public int Hp_Max;
    public int Hp_Regeneration;
    public int Player_Speed;
    public bool CloseLeftBorder;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
