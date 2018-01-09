using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschoss : PlayerWeapons
{ 
    public override void movment()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
    }
    public override void Destroy()
    {
        GameObject.Find("Spieler").GetComponent<Spieler>().GeschossCount--;
        Destroy(this.gameObject);
    }
}
