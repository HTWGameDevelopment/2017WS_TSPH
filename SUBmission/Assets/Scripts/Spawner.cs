using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] spawnable;
    public float minhight;
    public float maxhight;
  
	
	// Update is called once per frame
	void Update () {
        spawner();
        minhight = spawnheight()[0];
        maxhight = spawnheight()[1];

    }
    public virtual void spawner()
    {
    
    }
    virtual public bool spawnCondition(GameObject g)
    {
        return true;
    }
    
    virtual public bool notToMuch(GameObject g)
    {
        return true;
    }
    public float[] spawnheight()
    {
        float[] hits = new float[2];
        Debug.DrawLine(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, -5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, 5f), Color.yellow);
        RaycastHit2D hit = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, -5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, 5f), 1 << 9);
        if (hit.collider != null)
        {
            
            hits[0] = hit.centroid.y;
        }
         RaycastHit2D hit2 = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, 5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + 2f, -5f), 1 << 9);
     if (hit2.collider != null)
     {
        hits[1] = hit2.centroid.y;
        }

        return hits;
    }
}
