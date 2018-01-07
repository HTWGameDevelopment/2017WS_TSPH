using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschoss : PlayerWeapons
{ 
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().GeschossCount--;
            Destroy(this.gameObject);
        }
    }
    public override void movment()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().GeschossCount--;
            Destroy(this.gameObject);
        }
    }
}
