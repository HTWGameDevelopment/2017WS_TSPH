using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour {


	public float Max_Hp = 100f;
	public float Current_Hp = 0f;
	public int Coins = 0;
    public float Geschoss_Dmg=10f;
    public float Torpedo_Dmg = 20f;
    public float Explosion_Dmg = 50f;
    public float Explosion_DmgDelay = 0.1f;
    public float Explosion_DotDmg = 10f;
    public float Explosion_Tickrate = 0.2f;
    public int MaxGeschossCount = 3;
    public int GeschossCount = 0;
    public int Torpedos = 0;
    public int MaxTorpedos = 5;
	// Use this for initialization
	void Start () {
		Current_Hp = Max_Hp;
	}
	float eingabeFaktor = 8;
    public GameObject[] projectil;


	//  Update is called once per frame
	void Update () {
        movment();
        shoot();
	}
    void movment()
    {
        //Eingabe speichern
        float xEingabe = Input.GetAxis("Horizontal");
        float yEingabe = Input.GetAxis("Vertical");

        //Neue Position bestimmen

        float xNeu = transform.position.x + xEingabe * eingabeFaktor * Time.deltaTime;
        float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime;

        /*if (yNeu < -4f) {
			yNeu = -4f;
		} 

		if (yNeu > 4f) {
			yNeu = 4f;
		}*/

        Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 q = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        if (xNeu < p.x + -1.5f)
        {
            Current_Hp = 0f;
            xNeu = p.x + 1.5f;
        }

        if (xNeu > q.x - 1.5f)
        {
            xNeu = q.x - 1.5f;
        }





        transform.position = new Vector2(xNeu, yNeu);
    }


	void OnTriggerEnter2D(Collider2D coll)
	{
		

	    if (coll.gameObject.tag == "Environment")
		{
            resetPlayer();
            HealthChange(10);
		}
        if (coll.gameObject.tag == "Enemy" && coll.gameObject.name != "Harpune(Clone)")
        {
            resetPlayer();
        }

    }


	void HealthChange(int schaden){
		Current_Hp = Current_Hp-schaden;
        GameObject.Find("Dmg").GetComponent<PointSystem>().dmgrecived += schaden;
        if(Current_Hp<=0)
        {
            GameObject.Find("Dmg").GetComponent<PointSystem>().deaths++;
            Current_Hp = 0; }
	}
    void resetPlayer()
    {

            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 4, Screen.height / 2, 0))+new Vector3(0,spawnheight());
    }
    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (GeschossCount < MaxGeschossCount)
            {
                Instantiate(projectil[0], new Vector3(this.transform.position.x + 2f, this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                GeschossCount++;
            }
        }
        else if (Input.GetButtonDown("Fire2"))
            {

                if (Torpedos>0)
                {
                    Instantiate(projectil[1], new Vector3(this.transform.position.x + 2f, this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                    Torpedos--;
                }
            }
    }
    public float spawnheight()
    {
        float y = 0;
        if(freeSpawn(0))
        { return 0; }
            RaycastHit2D hit = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) , -5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) , 5f), 1 << 9);
            RaycastHit2D hit2 = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) , 5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) , -5f), 1 << 9);
            if (hit2.collider != null && hit.collider != null)
            {
                if (freeSpawn(y = (hit2.centroid.y + hit.centroid.y) / 2))
                { return (y); }
                else
                {   for(float d=hit.centroid.y;d<hit2.centroid.y;d+=0.5f)
                    {
                    if (freeSpawn(d))
                    { return (d); }
                    }
                return 0;
                }
            }
        return 0;
    }
    public bool freeSpawn(float y)
    {
        RaycastHit2D hit = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) + 4f, y-1.5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) - 4f, y-1.5f), 1 << 9);
        RaycastHit2D hit2 = Physics2D.Linecast(new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) + 4f, y+1.5f), new Vector2((Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 4, 0)).x) - 4f, y+1.5f), 1 << 9);
        return (hit.collider == null && hit2.collider == null);
    }

}
