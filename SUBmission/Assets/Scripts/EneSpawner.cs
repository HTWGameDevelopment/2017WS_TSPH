using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EneSpawner : Spawner
{

    public int JellyCounter = 0;
    public int MaxJelly = 3;
    public float jellyWarsch=0f;
    public int SharkCounter = 0;
    public int MaxShark = 2;
    public float sharkWarsch=0f;
    public int DiverCounter = 0;
    public int MaxDiver = 3;
    public float diverWarsch=0f;
    public int harpunenCounter = 0;//diver
    public int MaxHarpunen = 3;
    public int bulletCounter = 0;
    public int MaxBullet = 3;
    public float spawnDelay = 2f;
    float spawnCounterDiver = 0f;
    float spawnCounterJelly = 0f;
    float spawnCounterShark = 0f;
    public override void spawner()
    {
        if (SceneManager.GetActiveScene().name=="OpenSea")
        {
            MaxJelly = 3;
            MaxShark = 1;
            MaxDiver = 1;
            jellyWarsch = 80f*(1-(JellyCounter)/(MaxJelly));
            sharkWarsch = 10f * (1-(SharkCounter)/(MaxShark));
            diverWarsch = 1f * (1-(DiverCounter) / (MaxDiver));
        }
        else if(SceneManager.GetActiveScene().name == "Cave")
        {
            MaxJelly = 2;
            MaxShark = 3;
            MaxDiver = 2;
            jellyWarsch = 20f * (1 - (JellyCounter) / (MaxJelly));
            sharkWarsch = 60f * (1 - (SharkCounter) / (MaxShark));
            diverWarsch = 40f * (1 - (DiverCounter) / (MaxDiver));
        }
        else if (SceneManager.GetActiveScene().name == "Indoor")
        {
            MaxJelly = 1;
            MaxShark = 2;
            MaxDiver = 4;
            jellyWarsch = 5f * (1 - (JellyCounter) / (MaxJelly));
            sharkWarsch = 30f * (1 - (SharkCounter) / (MaxShark));
            diverWarsch = 80f * (1 - (DiverCounter) / (MaxDiver));
        }
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
            if (spawnCounterJelly >= spawnDelay)
            {
                spawnCounterJelly = 0-JellyCounter/MaxJelly * Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < jellyWarsch;
            }
            else
            {
                spawnCounterJelly+=Time.deltaTime;
                return false;
            }

        }
        else if (g.name == ("Shark"))
        {
            if (spawnCounterShark >= spawnDelay)
            {
                spawnCounterShark = 0-SharkCounter/MaxShark* Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < sharkWarsch;
            }
            else
            {
                spawnCounterShark+=Time.deltaTime;
                return false;
            }
        }
        else if (g.name == ("Diver"))
        {
            if (spawnCounterDiver >= spawnDelay)
            {
                spawnCounterDiver = 0-DiverCounter/MaxDiver * Random.Range(0f, 2f);
                return Random.Range(0f, 100f) < diverWarsch;
            }
            else
            {
                spawnCounterDiver+= Time.deltaTime;
                return false;
            }
        }
        else return false;
    }
}
