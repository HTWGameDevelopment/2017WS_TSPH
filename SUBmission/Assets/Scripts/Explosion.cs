using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PlayerWeapons
{
    public float destroyDelay = 2f;
    public float tick = 0f;
    public bool dot = false;
    bool dmgdealed = false;
    private void Start()
    {
        tick = 0f;
    }
    public override void OnTriggerEnter2D(Collider2D col)
    {
        
    }
    public override void spezial()
    {
        float Dmg_Delay = GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_DmgDelay;
        float tickrate = GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Tickrate;
        destroyDelay -= Time.deltaTime;
        if (destroyDelay <= 0)
        {
            Destroy(this.gameObject);
        }
        tick += Time.deltaTime;
        if(tick>=tickrate&&dot)
        {
            AoeDmg(GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_DotDmg);
            tick = 0f;
        }
        else if(tick >= Dmg_Delay && !dot&&!dmgdealed)
        {
            dmgdealed = true;
            AoeDmg(GameObject.Find("Spieler").GetComponent<Spieler>().Explosion_Dmg);
        }



    }
    public void AoeDmg(float dmg)//add everything that should be dmged by the explosion
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x - 0.07261234f, transform.position.y - 0.1657762f), 2.836893f, 1 << 8);
        foreach (Collider2D en in enemies)
        {
            if (en.gameObject.name != "Harpune(Clone)" && en.gameObject.name != "TurretShot(Clone)")
            {
                GameObject.Find("Dmg").GetComponent<PointSystem>().dmgdone += dmg;
            }
                if (en.gameObject.name == "Shark(Clone)")
                {
                    Shark shark = en.gameObject.GetComponent<Shark>();
                    shark.Current_Hp -= dmg;
                }
                else if (en.gameObject.name == "JellyFish(Clone)")
                {
                    JellyFish jellyFish = en.gameObject.GetComponent<JellyFish>();
                    jellyFish.Current_Hp -= dmg;
                }
                else if (en.gameObject.name == "Diver(Clone)")
                {
                    Diver diver = en.gameObject.GetComponent<Diver>();
                    diver.Current_Hp -= dmg;
                }
                else if (en.gameObject.name == "Turret(Clone)")
                {
                    Turret turret = en.gameObject.GetComponent<Turret>();
                    turret.Current_Hp -= dmg;
                }
                else if (en.gameObject.name == "Harpune(Clone)")
                {
                    GameObject.Find("Enemy").GetComponent<EneSpawner>().harpunenCounter--;
                    Destroy(this.gameObject);
                }
                else if (en.gameObject.name == "TurretShot(Clone)")
                {
                    GameObject.Find("Enemy").GetComponent<EneSpawner>().bulletCounter--;
                    Destroy(this.gameObject);
                }
            }
    }
}
