using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy {
    public GameObject bullets;
    public GameObject turretBarrel;
    public GameObject exitPoint;
    public float timeDelayBetweenShoots=2f;
    public float time=0f;
    public float winkel=0f;
	// Use this for initialization
	void Start () {
        Max_Hp = 30f;
        Collision_Dmg = 50f;
        Current_Hp = Max_Hp;
        time = 0f;

    }
    public override void movment()
    {
        Vector3 rotation = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
        rotation = einheitsVector(rotation);
        winkel = Mathf.Atan2(rotation.y, rotation.x) / Mathf.PI * 180f;
        turretBarrel.transform.rotation = Quaternion.Euler(0, 0, winkel+180f);
    }
    public override void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.tag == "Player")
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp -= Collision_Dmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            Current_Hp = Max_Hp;
            Destroy(this.gameObject);
            //type.SetActive(false);
        }
        else if (co.gameObject.tag == "Geschoss")
        {
            if (co.gameObject.name == "Geschoss(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Geschoss_Dmg;
                if (Current_Hp <= 0)
                {
                    Current_Hp = Max_Hp;
                    Destroy(this.gameObject);
                }
            }

            else if (co.gameObject.name == "Torpedo(Clone)" || co.gameObject.name == "Exlposion(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Torpedo_Dmg;
                if (Current_Hp <= 0)
                {
                    Current_Hp = Max_Hp;
                    Destroy(this.gameObject);
                }
            }
        }
    }
    public override void shooting(GameObject g)
    {
        Vector3 rotation = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position -turretBarrel.transform.position;
        rotation = einheitsVector(rotation);
        winkel = Mathf.Atan2(rotation.y, rotation.x) / Mathf.PI * 180f;
        Instantiate(g, exitPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, winkel)));


        GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter++;
        time = 0;
    }
    public override void fire()
    {
        time += Time.deltaTime;
        if (time >= timeDelayBetweenShoots && GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter < GameObject.Find("Enemy").GetComponent<EneSpawner>().MaxBullet)
        {
            shooting(bullets);
        }
    }
}
