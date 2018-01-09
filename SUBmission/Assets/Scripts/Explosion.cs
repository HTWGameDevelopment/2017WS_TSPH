using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PlayerWeapons
{
    public float destroyDelay = 2f;
    public float tick = 0f;
    public override void OnTriggerEnter2D(Collider2D col)
    {
        
    }
    public override void spezial()
    {
        float tickrate = GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Tickrate;
        
        destroyDelay -= Time.deltaTime;
        if (destroyDelay <= 0)
        {
            Destroy(this.gameObject);
        }
        tick += Time.deltaTime;
        if(tick>=tickrate)
        {
            AoeDmg();
            tick = 0f;
        }



    }
    public void AoeDmg()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x - 0.07261234f, transform.position.y - 0.1657762f), 2.836893f, 1 << 8);
        foreach (Collider2D en in enemies)
        {
            if (en.gameObject.name != "Harpune(Clone)")
            {
                if (en.gameObject.name == "Shark(Clone)")
                {
                    Shark shark = en.gameObject.GetComponent<Shark>();
                    shark.Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Dmg;
                }
                else if (en.gameObject.name == "JellyFish(Clone)")
                {
                    JellyFish jellyFish = en.gameObject.GetComponent<JellyFish>();
                    jellyFish.Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Dmg;
                }
                else if (en.gameObject.name == "Diver(Clone)")
                {
                    Diver diver = en.gameObject.GetComponent<Diver>();
                    diver.Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Dmg;
                }
            }
            else
            {
                Destroy(en.gameObject);
            }
        }
    }
}
