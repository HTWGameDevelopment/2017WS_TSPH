using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Enemy
{
    public float speed = 0.02f;

    void Start()
    {
        Max_Hp = 100f;
        Collision_Dmg = 60f;
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
					GameObject.Find ("Spieler").GetComponent<Spieler> ().Coins+=3;
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

