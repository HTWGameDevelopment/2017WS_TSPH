using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : Enemy {

    Vector3 direction;
    public float speed = 0.05f;
    public float bulletDmg = 20f;
    // Use this for initialization
    void Start()
    {
        direction = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
        direction = einheitsVector(direction);

    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
            GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp -= bulletDmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter--;
            Destroy(this.gameObject);
        }
        /*else if (col.gameObject.tag == "Geschoss")
        {
            Destroy(this.gameObject);
        }*/
    }
    public override void movment()
    {
        this.transform.position += direction * speed;
    }
    public override void destroyOoS(GameObject g)
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter--;
        Destroy(g);
    }
    public override void transformHealth()
    {
    }
}
