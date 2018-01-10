using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        movment();
        spezial();
        if(exactOutOfScreen(this.gameObject)&&this.gameObject.name!= "Torpedo(Clone)")
        {
            Destroy();
        }
        else if(exactOutOfScreen(this.gameObject)&&this.gameObject.name == "Torpedo(Clone)")
        {
            Destroy(this.gameObject);
        }
		
	}
    public virtual void movment()
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && col.gameObject.name != "Harpune(Clone)")
        {
            Destroy();
        }
        else if(col.gameObject.tag=="Environment")
        {
            Destroy();
        }
    }
    public bool exactOutOfScreen(GameObject g)
    {
        return (g.transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x || g.transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y || g.transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y || g.transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
    }
    public virtual void Destroy()
    {
        Destroy(this.gameObject);
    }
     public virtual void spezial()
    {

    }
   
}
