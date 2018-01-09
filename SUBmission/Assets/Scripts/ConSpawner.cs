using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConSpawner : Spawner
{
    public int coinCounter=0;
    public int maxCoin = 2;
    public int HpUpCounter=0;
    public int MaxHpUp=2;
    public int TBoxCounter = 0;
    public int MaxTBox = 2;
    int spawnCounterCoin = 0;
    int spawnCounterTBox = 0;
    int spawnCounterHp = 0;
    public override void spawner()
    {
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
            if (spawnCounterCoin == 10)
            {
                spawnCounterCoin = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterCoin++;
                return false;
            }

        }
        else if (g.tag==("HpUp"))
        {
            if (spawnCounterHp == 10)
            {
                spawnCounterHp = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterHp++;
                return false;
            }
        }
        else if (g.tag == ("TorpedoBox"))
        {
            if (spawnCounterTBox == 10)
            {
                spawnCounterTBox = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterTBox++;
                return false;
            }
        }
        else return false;
    }

}
