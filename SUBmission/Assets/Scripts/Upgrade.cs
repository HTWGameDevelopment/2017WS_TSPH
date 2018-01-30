using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGreate : MonoBehaviour
{
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
    void Start()
    {
        Geschoss_Dmg = 0;
        Geschoss_Count = 0;
        Geschoss_Speed = 0;
        Torpedo_Reserve = 0;
        Torpedo_Dmg = 0;
        Torpedo_Regeneration = 0;
        Torpedo_Dot = 0;
        Torpedo_Tickrate = 0;
        Hp_Max = 0;
        Hp_Regeneration = 0;
        Player_Speed = 0;
        CloseLeftBorder = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
}