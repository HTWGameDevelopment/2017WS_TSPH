using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : PlayerWeapons
{
    public GameObject Explosion;
    public float speed = 0.05f;
    public override void movment()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime * 75, 0, 0);
    }
    public override void Destroy()
    {
        Instantiate(Explosion, new Vector3(this.transform.position.x, this.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }
}
