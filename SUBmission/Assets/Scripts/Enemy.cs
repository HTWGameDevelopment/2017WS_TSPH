using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject healthBar;
    public GameObject type;
    public float Max_Hp=100f;
    public float Current_Hp;
    public float Collision_Dmg=10f;
    float calcHealth;
    // Use this for initialization
    void Start () {
        Current_Hp = Max_Hp;
    }
	
	// Update is called once per frame
	void Update () {
        //spawner();
        transformHealth();
        movment();
        if(outOfScreen(this.gameObject))
        {
            destroyOoS(this.gameObject);
        }
        fire();

    }
    virtual public void movment()
    {
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
                if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp <0)
                { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            Current_Hp = Max_Hp;
            Destroy(this.gameObject);
               //type.SetActive(false);
        }
        else if (co.gameObject.tag=="Geschoss")
        {
            Current_Hp-=GameObject.Find("Spieler").GetComponent<Spieler>().Geschoss_Dmg;
            if (Current_Hp <= 0)
            {
                Current_Hp = Max_Hp;
                Destroy(this.gameObject);
               //type.SetActive(false);
            }
        }
    }
    public bool outOfScreen(GameObject g)
    {
        return (g.transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(-4f, 0, 0)).x || g.transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, -4f, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height+4f, 0)).y|| g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width+5f, 0, 0)).x);
    }
    public virtual void destroyOoS(GameObject g)
    {

    }
    public virtual void shooting(GameObject g)
    {

    }
    public virtual void fire()
    {

    }
    public Vector3 einheitsVector(Vector3 v)
    {
        float d = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        v.x /= d;
        v.y /= d;
        return v;
    }
}
