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
        if(Current_Hp==0&&this.gameObject.name!="Harpune(Clone)")
        { destroyOoS(this.gameObject); }

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
            if (GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp < 0)
            { GameObject.Find("Spieler").GetComponent<Spieler>().Current_Hp = 0; }
            Current_Hp = Max_Hp;
            Destroy(this.gameObject);
        }
        else if (co.gameObject.tag == "Geschoss")
        {
            if (co.gameObject.name == "Geschoss(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Geschoss_Dmg;
                if (Current_Hp <= 0)
                {
                    Current_Hp = Max_Hp;
                    Destroy(this.gameObject);
                }
            }

            else if (co.gameObject.name == "Torpedo(Clone)" || co.gameObject.name == "Exlposion(Clone)")
            {
                Current_Hp -= GameObject.Find("Spieler").GetComponent<Spieler>().Torpedo_Dmg;
                if (Current_Hp <= 0)
                {
                    Current_Hp = Max_Hp;
                    Destroy(this.gameObject);
                }
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
    public Vector2 einheitsVector2D(Vector2 v)
    {
        float d = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        v.x /= d;
        v.y /= d;
        return v;
    }

    public virtual Vector2 environmentCheck()
    {
        Vector2 vec=new Vector2(0,0);
        float a=1f;
        float b = 0f;
        Vector2 center = new Vector2((this.transform.position).x, (this.transform.position).y) + new Vector2(this.GetComponent<CapsuleCollider2D>().offset.x, this.GetComponent<CapsuleCollider2D>().offset.y);
        /*Collider2D[] env = Physics2D.OverlapBoxAll(center, new Vector2(this.GetComponent<CapsuleCollider2D>().size.x*this.GetComponent<Transform>().lossyScale.x, this.GetComponent<CapsuleCollider2D>().size.y) * this.GetComponent<Transform>().lossyScale.y, 0, 1 << 9);
       foreach (Collider2D co in env)
        {
            if(co.gameObject.tag=="Environment")
            vec += einheitsVector2D(vec + einheitsVector2D(new Vector2((co.transform.position).x, (co.transform.position).y) - center));
        }*/
        RaycastHit2D hit = Physics2D.Linecast(new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + a), center.y - (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + a * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + b), center.y - (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + b * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), 1 << 9);
        Debug.DrawLine(new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x/2 * this.GetComponent<Transform>().lossyScale.x + a), center.y - (this.GetComponent<CapsuleCollider2D>().size.y/2 * this.GetComponent<Transform>().lossyScale.y +a* this.GetComponent<CapsuleCollider2D>().size.y/ this.GetComponent<CapsuleCollider2D>().size.x)), new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x/2 * this.GetComponent<Transform>().lossyScale.x + b), center.y - (this.GetComponent<CapsuleCollider2D>().size.y/2 * this.GetComponent<Transform>().lossyScale.y + b* this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), Color.red);
        if(hit.collider!=null)
        {
            return einheitsVector2D(-einheitsVector2D(hit.centroid - center)+new Vector2(0,1));
        }
        RaycastHit2D hit2 = Physics2D.Linecast(new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + a), center.y + (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + a * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + b), center.y + (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + b * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), 1 << 9);
        Debug.DrawLine(new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + a), center.y + (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + a * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), new Vector2(center.x - (this.GetComponent<CapsuleCollider2D>().size.x / 2 * this.GetComponent<Transform>().lossyScale.x + b), center.y + (this.GetComponent<CapsuleCollider2D>().size.y / 2 * this.GetComponent<Transform>().lossyScale.y + b * this.GetComponent<CapsuleCollider2D>().size.y / this.GetComponent<CapsuleCollider2D>().size.x)), Color.red);
        if (hit2.collider != null)
        {
            return einheitsVector2D(-einheitsVector2D(hit2.centroid - center) - new Vector2(0, 1));
        }
        return vec;
    }
}
