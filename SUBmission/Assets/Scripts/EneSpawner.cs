using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneSpawner : Spawner
{

    public int JellyCounter = 0;
    public int MaxJelly = 2;
    public int SharkCounter = 0;
    public int MaxShark = 2;
    public int DiverCounter = 0;
    public int MaxDiver = 2;
    public int harpunenCounter = 0;//diver
    public int MaxHarpunen = 3;
    public int bulletCounter = 0;
    public int MaxBullet = 3;
    int spawnCounterDiver = 0;
    int spawnCounterJelly = 0;
    int spawnCounterShark = 0;
    public override void spawner()
    {
        for (int i = 0; i < spawnable.Length; i++)
        {
            if (spawnCondition(spawnable[i]) && notToMuch(spawnable[i]))
            {
                Instantiate(spawnable[i], new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f, y: Random.Range(minhight+0.8f, maxhight-0.8f), z: 1), new Quaternion(0, 0, 0, 0));
                if (spawnable[i].name==("JellyFish"))
                {
                    JellyCounter++;
                }
                else if (spawnable[i].name == ("Shark"))
                {
                    SharkCounter++;
                }
                else if (spawnable[i].name == ("Diver"))
                {
                    DiverCounter++;
                }
            }

        }
    }
    override public bool notToMuch(GameObject g)
    {
        if (g.name == ("JellyFish"))
        {
            return JellyCounter < MaxJelly;
        }
        else if (g.name == ("Shark"))
        {
            return SharkCounter < MaxShark;
        }
        else if (g.name == ("Diver"))
        {
            return DiverCounter < MaxDiver;
        }
        else return false;

    }
    public override bool spawnCondition(GameObject g)
    {
        if (g.name == ("JellyFish"))
        {
            if (spawnCounterJelly == 10)
            {
                spawnCounterJelly = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterJelly++;
                return false;
            }

        }
        else if (g.name == ("Shark"))
        {
            if (spawnCounterShark == 10)
            {
                spawnCounterShark = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterShark++;
                return false;
            }
        }
        else if (g.name == ("Diver"))
        {
            if (spawnCounterDiver == 10)
            {
                spawnCounterDiver = 0;
                return Random.Range(0f, 100f) < 100f;
            }
            else
            {
                spawnCounterDiver++;
                return false;
            }
        }
        else return false;
    }
}
