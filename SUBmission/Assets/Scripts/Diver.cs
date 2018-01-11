using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : Enemy
{

    public float speed = 0.02f;
    public float timeDelayBetweenshoots=2f;
    public GameObject Harpune;
    float winkel;
    float time=0;

    void Start()
    {
        Max_Hp = 10f;
        Collision_Dmg = 10f;
        Current_Hp = Max_Hp;
        time = 0;
    }
   
    public override void movment()
    {
        
        if (environmentCheck().x == 0 && environmentCheck().y == 0)
        {
            Vector3 nextMove = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
            this.transform.position += speed * einheitsVector(nextMove); 
        }
        else
        {

            this.transform.position += new Vector3(environmentCheck().x, environmentCheck().y, 0) * (speed + 0.02f);
        }
    }
    public override void destroy()
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().DiverCounter--;
        Destroy(this.gameObject);
    }
    public override void shooting(GameObject g)
    {

        Vector3 rotation = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
            rotation = einheitsVector(rotation);
        winkel = Mathf.Atan2(rotation.y, rotation.x) / Mathf.PI * 180f;
        Instantiate(g, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y), Quaternion.Euler(new Vector3(0,0,winkel)));
        
        GameObject.Find("Enemy").GetComponent<EneSpawner>().harpunenCounter++;
        time = 0;
    }
    public override void fire()
    {
        time += Time.deltaTime;
        if (time >= timeDelayBetweenshoots && GameObject.Find("Enemy").GetComponent<EneSpawner>().harpunenCounter < GameObject.Find("Enemy").GetComponent<EneSpawner>().MaxHarpunen)
        {
            shooting(Harpune);
        }
    }

}
