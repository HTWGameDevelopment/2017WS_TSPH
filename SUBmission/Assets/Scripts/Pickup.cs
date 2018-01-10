using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    private void Update()
    {
        if(outOfScreen(this.gameObject))
        {
            if (this.gameObject.tag == "HpUp")
            {
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().HpUpCounter--;
                    }
            else if (this.gameObject.tag == "Coin")
            {
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().coinCounter--;
            }
            else if (this.gameObject.tag == "TorpedoBox")
            {
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().TBoxCounter--;
            }

            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (this.gameObject.tag == "HpUp")
			{
				GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp += 0.1f * GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp;
				if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp > GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp)
				{ GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = GameObject.Find("Spieler").GetComponent<Spieler>().Max_Hp; }
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().HpUpCounter--;
                Destroy(this.gameObject);
                


            }
			else if (this.gameObject.tag=="Coin")
			{
				GameObject.Find("Spieler").GetComponent<Spieler>().Coins++;
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().coinCounter--;
                Destroy(this.gameObject);
            }
            else if (this.gameObject.tag == "TorpedoBox"&& GameObject.Find("Spieler").GetComponent<Spieler>().Torpedos< GameObject.Find("Spieler").GetComponent<Spieler>().MaxTorpedos)
            {
                GameObject.Find("Spieler").GetComponent<Spieler>().Torpedos++;
                GameObject.Find("Collectibles").GetComponent<ConSpawner>().TBoxCounter--;
                Destroy(this.gameObject);
            }

        }

    }
    public bool outOfScreen(GameObject g)
    {
        return (g.transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(-4f, 0, 0)).x || g.transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, -4f, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + 4f, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 5f, 0, 0)).x);
    }
}
