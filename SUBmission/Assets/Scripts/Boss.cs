using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject healthBar;
    public GameObject harpune;
    public GameObject ziel;
    public float Max_Hp = 1000f;
    public float Current_Hp;
    public float Collision_Dmg = 50f;
    public float timeDelayBetweenshoots = 2f;
    float calcHealth;
    float winkel;
    float time = 0;
    public float atckCd = 0;
    bool jumpUp;
    bool jumpDown;
    bool chargeTo;
    bool chargeBack;
    public float speed = 0.05f;
    public bool atack;
    float point;
    // Use this for initialization
    void Start()
    {
        Max_Hp = 1000f;
        Collision_Dmg = 50f;
        Current_Hp = Max_Hp;
        time = 0;
        atack = false;
        jumpUp = true;
        point = GameObject.Find("BossStage 1 1(Clone)").GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transformHealth();
        fire();
        if (Current_Hp <= 0 )
        { destroy(); }
        if (atack)
        { charge(); }
        else movment();

    }
    virtual public void movment()
    {
        if (atckCd < 10f)
        {
            atckCd += Time.deltaTime;
        }
        if (point < this.transform.position.x )
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime * 75, 0, 0);
        }
        if (point > this.transform.position.x && !atack)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime * 75, 0, 0);
        }
        if(atckCd>=10f)
        {
            atack = true;
            atckCd = 0f;
        }
        if (this.transform.position.x < point - 15f)
        {
            this.transform.position = new Vector3(point - 15f, 0, -10);
        }
        if (this.transform.position.x > point + 15f)
        {
            this.transform.position = new Vector3(point + 15f, 0, -10);
        }
    }
    public void charge()
    {
        if (jumpUp)
        {
            this.transform.position += new Vector3(0, speed * Time.deltaTime * 75 , 0);
            if(this.transform.position.y >= 1f)
            {
                jumpUp = false;
                jumpDown = true;
            }
        }
        else if (jumpDown)
        {
            this.transform.position += new Vector3(0, -speed * Time.deltaTime * 75, 0);
            if (this.transform.position.y <= -1f)
            {
                chargeTo = true;
                jumpDown = false;
            }
        }
        else if (chargeTo)
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime * 75 *2, 0);
            if (this.transform.position.x <= GameObject.Find("Spieler").transform.position.x)
            {
                chargeTo = false;
                chargeBack = true;
            }
        }
        if (chargeBack)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime * 75 * 2, 0);
            if (this.transform.position.x >= GameObject.Find("Spieler").transform.position.x+7f)
            {
                atack = false;
                chargeBack = false;
                jumpUp = true;
            }
        }
    }
    public virtual void transformHealth()
    {
        calcHealth = Current_Hp / Max_Hp;
        healthBar.transform.localScale = new Vector3(calcHealth, 1, 1);
    }

    public virtual void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.tag == "Player")
        {
            GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp -= Collision_Dmg;
            GameObject.Find("Dmg").GetComponent<PointSystem>().dmgrecived += Collision_Dmg;
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            {
                GameObject.Find("Dmg").GetComponent<PointSystem>().deaths++;
                GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0;
            }
        }
        else if (co.gameObject.tag == "Geschoss")
        {
            if (co.gameObject.name == "Geschoss(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Geschoss_Dmg;
                if (Current_Hp <= 0)
                {
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
    public bool outOfScreen(GameObject g)
    {
        return (g.transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(-4f, 0, 0)).x || g.transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, -4f, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height + 4f, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 5f, 0, 0)).x);
    }
    public virtual void destroy()
    {
        Instantiate(ziel, new Vector3((Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x) + 2f, 0, 1), new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }
    public void shooting(GameObject g)
    {
        Vector3 rotation = GameObject.Find("Spieler").GetComponent<Spieler>().transform.position - this.transform.position;
        rotation = einheitsVector(rotation);
        winkel = Mathf.Atan2(rotation.y, rotation.x) / Mathf.PI * 180f;
        Instantiate(g, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y), Quaternion.Euler(new Vector3(0, 0, winkel)));
        time = 0;
    }
    public virtual void fire()
    {
        time += Time.deltaTime;
        if (time >= timeDelayBetweenshoots )
        {
            shooting(harpune);
        }

    }
    public Vector3 einheitsVector(Vector3 v)
    {
        float d = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        v.x /= d;
        v.y /= d;
        return v;
    }
    public Vector2 einheitsVector2D(Vector2 v)
    {
        float d = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        v.x /= d;
        v.y /= d;
        return v;
    }

   
}
