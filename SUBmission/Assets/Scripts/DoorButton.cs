using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {
    public GameObject door;
    public float cloasingSpeed = 0.5f;
    public Sprite button2;
    public GameObject boss;
    bool hit = false;
    bool bossSpawned;
	// Use this for initialization
	void Start () {
        hit = false;
        bossSpawned = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(hit)
        { openDoor(); }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Geschoss"&& this.gameObject.GetComponent<SpriteRenderer>().sprite != button2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = button2;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit = true;
        }
    }
    void openDoor()
    {
        door.transform.position -=new Vector3(0,cloasingSpeed);
        if(door.transform.position.y<=-11)
        { Destroy(door);
            hit = false;
        }
       if( GameObject.Find("Environment").GetComponent<BackrSpawner>().bossRoom&&!bossSpawned)
        {
            Instantiate(boss, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f,-1f,1), new Quaternion(0, 0, 0, 0));
            bossSpawned = true;
        }
    }

}
