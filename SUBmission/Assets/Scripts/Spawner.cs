using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] spawnable;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawner();

    }
    public virtual void spawner()
    {
       /* for (int i = 0; i < spawnable.Length; i++)
        {
            if (Random.Range(0f, 1000f) < 500f && (!spawnable[i].activeSelf || outOfScreen(spawnable[i]))&& spawnCondition(spawnable[i]))
            {
                spawnable[i].transform.position = new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f, y: Random.Range(-4f, 4f), z: 0);
                spawnable[i].SetActive(true);
            }
        }
      /*  for (int i = 0; i < spawnable.Length; i++)
        {
            if (spawnCondition(spawnable[i])&& notToMuch(spawnable[i]))
            {
               a= Instantiate(spawnable[i], new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f, y: Random.Range(-4f, 4f), z: 1),new Quaternion(0,0,0,0));
                active.Add(a);
            }
        }*/
    }
    virtual public bool spawnCondition(GameObject g)
    {
        return true;
    }
    
    virtual public bool notToMuch(GameObject g)
    {
        return true;
    }
}
