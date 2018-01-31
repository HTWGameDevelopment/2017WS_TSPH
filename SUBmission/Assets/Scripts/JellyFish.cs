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
        Collision_Dmg = 40f;
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

	public override void OnTriggerEnter2D(Collider2D co)
	{
		if (co.gameObject.tag == "Player")
		{
			GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp -= Collision_Dmg;
			GameObject.Find("Dmg").GetComponent<PointSystem>().dmgrecived += Collision_Dmg;
			if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
			{
				GameObject.Find("Dmg").GetComponent<PointSystem>().deaths++;
				GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
			Current_Hp = Max_Hp;
			destroy();
		}
		else if (co.gameObject.tag == "Geschoss")
		{
			if (co.gameObject.name == "Geschoss(Clone)")
			{
				Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Geschoss_Dmg;
				if (Current_Hp <= 0)
				{
					GameObject.Find ("Spieler").GetComponent<Spieler> ().Coins++;
					Current_Hp = Max_Hp;
					destroy();
				}
			}

			else if (co.gameObject.name == "Torpedo(Clone)" || co.gameObject.name == "Exlposion(Clone)")
			{
				Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Torpedo_Dmg;
				if (Current_Hp <= 0)
				{
					Current_Hp = Max_Hp;
					destroy();
				}
			}
		}
	}
}
