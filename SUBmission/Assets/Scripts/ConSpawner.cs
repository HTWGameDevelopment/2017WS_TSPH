using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConSpawner : Spawner
{
    public int coinCounter=0;
    public int maxCoin = 2;
    public float coinWarsch = 0f;
    public int HpUpCounter=0;
    public int MaxHpUp=2;
    public float hpupWarsch = 0f;
    public int TBoxCounter = 0;
    public int MaxTBox = 2;
    public float tboxWarsch = 0f;
    public float spawnDelay=5f;
    float spawnCounterCoin = 0f;
    float spawnCounterTBox = 0f;
    float spawnCounterHp = 0f;
    public override void spawner()
    {
        coinWarsch = 80f;
        hpupWarsch = (1-GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp / GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp)*70+30;
        tboxWarsch = (1 - (GameObject.Find("Spieler").GetComponent<Spieler>().Torpedos / GameObject.Find("Spieler").GetComponent<Spieler>().MaxTorpedos)) * 60+10;
        for (int i = 0; i < spawnable.Length; i++)
        {
            if (spawnCondition(spawnable[i]) && notToMuch(spawnable[i]))
            {
                Instantiate(spawnable[i], new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f, y: Random.Range(minhight + 0.8f, maxhight - 0.8f), z: 1), new Quaternion(0, 0, 0, 0));
                if (spawnable[i].tag==("Coin"))
                {
                    coinCounter++;
                }
                else if (spawnable[i].tag==("HpUp"))
                {
                    HpUpCounter++;
                }
                else if (spawnable[i].tag == ("TorpedoBox"))
                {
                    TBoxCounter++;
                }
            }

        }
    }
    override public bool notToMuch(GameObject g)
    {
        if (g.tag==("Coin"))
        {
            return coinCounter < maxCoin;
        }
        else if (g.tag==("HpUp"))
        {
            return HpUpCounter < MaxHpUp;
        }
        else if (g.tag == ("TorpedoBox"))
        {
            return TBoxCounter < MaxTBox;
        }
        else return false;
        
    }
    public override bool spawnCondition(GameObject g)
    {
        if (g.tag==("Coin"))
        {
            if (spawnCounterCoin >= spawnDelay)
            {
                spawnCounterCoin = 0-Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < coinWarsch;
            }
            else
            {
                spawnCounterCoin+= Time.deltaTime;
                return false;
            }

        }
        else if (g.tag==("HpUp"))
        {
            if (spawnCounterHp >= spawnDelay)
            {
                spawnCounterHp = 0- Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < hpupWarsch;
            }
            else
            {
                spawnCounterHp+=Time.deltaTime;
                return false;
            }
        }
        else if (g.tag == ("TorpedoBox"))
        {
            if (spawnCounterTBox >= spawnDelay)
            {
                spawnCounterTBox = 0- Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < tboxWarsch;
            }
            else
            {
                spawnCounterTBox+= Time.deltaTime;
                return false;
            }
        }
        else return false;
    }

}
