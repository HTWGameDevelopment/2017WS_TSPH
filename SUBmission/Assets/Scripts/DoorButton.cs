using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {
    public GameObject door;
    public float cloasingSpeed = 0.5f;
    public Sprite button2;
    bool hit = false;
	// Use this for initialization
	void Start () {
        hit = false;
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
    }

}
