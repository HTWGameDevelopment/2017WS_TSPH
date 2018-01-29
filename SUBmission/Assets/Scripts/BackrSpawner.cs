using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackrSpawner : Spawner
{
    public int boxSpawned = 0;
    public int activeBox = 0;
    public GameObject endBox;
    void Start()
    {
        Instantiate(spawnable[Random.Range(0, spawnable.Length)], new Vector3(x:0, y: 0, z: 1), new Quaternion(0, 0, 0, 0));
        boxSpawned++;
        activeBox++;

    }

    public override void spawner()
    {
        if (activeBox < 2)
        {
            RaycastHit2D hit = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 4f, -5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 4f, 5f));
            if (hit.collider == null)
            {
                if (boxSpawned%9!=0)
                {
                    Instantiate(spawnable[Random.Range(0, spawnable.Length)], new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 4f + 25.62f, y: 0, z: 1), new Quaternion(0, 0, 0, 0));
                    boxSpawned++;
                    activeBox++;
                }
                else if (boxSpawned%9==0)
                {
                    Instantiate(endBox, new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 4f + 25.62f, y: 0, z: 1), new Quaternion(0, 0, 0, 0));
                    boxSpawned++;
                    activeBox++;
                }
            }
        }
    }
}
