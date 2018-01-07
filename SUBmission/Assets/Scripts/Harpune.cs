using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpune : Enemy
{
    Vector3 direction;
    public float speed = 0.05f;
    public float harpunenDmg=10f;
    // Use this for initialization
    void Start () {
        direction = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
        direction = einheitsVector(direction);

    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp-= harpunenDmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            GameObject.Find("Enemy").GetComponent<EneSpawner>().harpunenCounter--;
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Geschoss")
        {
                Destroy(this.gameObject);
        }
    }
    public override void movment()
    {
        this.transform.position += direction*speed;
    }
    public override void destroyOoS(GameObject g)
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().harpunenCounter--;
        Destroy(g);
    }
    public override void transformHealth()
    {
    }
}
