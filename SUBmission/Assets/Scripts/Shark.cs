using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    public float speed = 0.02f;

    void Start()
    {
        Max_Hp = 100f;
        Collision_Dmg = 100f;
        Current_Hp = Max_Hp;
    }
    public override void movment()
    {
        if (environmentCheck().x == 0 && environmentCheck().y == 0)
        {
            this.transform.position -= new Vector3(speed, 0, 0);
        }
        else
        {

            this.transform.position += new Vector3(environmentCheck().x, environmentCheck().y, 0) * (speed+0.02f);
        }
        }
    public override void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.tag == "Player")
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp -= Collision_Dmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            Current_Hp = Max_Hp;
            GameObject.Find("Enemy").GetComponent<EneSpawner>().SharkCounter--;
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
                    GameObject.Find("Enemy").GetComponent<EneSpawner>().SharkCounter--;
                    Destroy(this.gameObject);
                    //type.SetActive(false);
                }
            }

            else if (co.gameObject.name == "Torpedo(Clone)" || co.gameObject.name == "Exlposion(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Torpedo_Dmg;
                if (Current_Hp <= 0)
                {
                    Current_Hp = Max_Hp;
                    GameObject.Find("Enemy").GetComponent<EneSpawner>().SharkCounter--;
                    Destroy(this.gameObject);
                    //type.SetActive(false);
                }
            }
        }
    }
    public override void destroyOoS(GameObject g)
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().SharkCounter--;
        Destroy(g);
    }
}

