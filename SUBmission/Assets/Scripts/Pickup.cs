using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	public GameObject consumable;
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (consumable.tag == "HpUp")
			{
				GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp += 0.1f * GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp;
				if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp > GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp)
				{ GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp; }
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().HpUpCounter--;
                Destroy(this.gameObject);
                


            }
			else if (consumable.tag=="Coin")
			{
				GameObject.Find("Spieler").GetComponent<Spieler>().Coins++;
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().coinCounter--;
                Destroy(this.gameObject);
            }
            
        }

    }
}
