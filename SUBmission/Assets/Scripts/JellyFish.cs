using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFish : Enemy {
    public float speed = 0.01f;
    public int range = 40;
    public int movmentCounter;
    void Start()
    {
        Max_Hp = 20f;
        Collision_Dmg = 50f;
        Current_Hp = Max_Hp;
        movmentCounter = 0;
        speed = 0.01f;
    }
    public override void movment()
    {
        if (movmentCounter < 40)
        {
            this.transform.position += new Vector3(0, speed * Time.deltaTime * 75, 0);
            movmentCounter++;
        }
        if(movmentCounter==40)
        {
            movmentCounter = -40;
            speed = -speed;
        }
    }

    public override void destroy()
    {
        GameObject.Find("Enemy").GetComponent<EneSpawner>().JellyCounter--;
        Destroy(this.gameObject);
    }
}
