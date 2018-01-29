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
            this.transform.position -= new Vector3(speed * Time.deltaTime * 75, 0, 0);
        }
        else
        {

            this.transform.position += new Vector3(environmentCheck().x, environmentCheck().y, 0) * (speed+0.02f) * Time.deltaTime * 75;
        }
        }
    public override void destroy()
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().SharkCounter--;
        Destroy(this.gameObject);
    }
}

