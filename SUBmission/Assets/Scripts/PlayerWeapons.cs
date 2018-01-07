using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movment();
		
	}
    public virtual void movment()
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && col.gameObject.name != "Harpune")
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().GeschossCount--;
            Destroy(this.gameObject);
        }
    }
}
