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
            GameObject.Find("Dmg").GetComponent<PointSystem>().dmgrecived += bulletDmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            {
                GameObject.Find("Dmg").GetComponent<PointSystem>().deaths++;
                GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0;
            }
            destroy();
        }
    }
    public override void movment()
    {
        this.transform.position += direction * speed * Time.deltaTime * 75;
    }
    public override void destroy()
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter--;
        Destroy(this.gameObject);
    }
    public override void transformHealth()
    {
    }
}
