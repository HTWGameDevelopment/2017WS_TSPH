using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float scrollSpeed=0.02f;
    public bool boss;
	// Use this for initialization
	void Start () {
        scrollSpeed = 0.02f;
        boss = false;

    }

	// Update is called once per frame
	void LateUpdate () {
		if(!boss)
        { normalMovment(); }
        else
        { bossFight(); }

	}
    void normalMovment()
    {
        GameObject.Find("Main Camera").transform.position += new Vector3(scrollSpeed * Time.deltaTime * 75, 0, 0);
    }
    void bossFight()
    {
        float point=GameObject.Find("BossStage 1 1(Clone)").GetComponent<Transform>().position.x;
        GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Spieler").GetComponent<Transform>().position.x + 4f, 0, -10);
        if(GameObject.Find("Main Camera").transform.position.x<point-15f)
        {
            GameObject.Find("Main Camera").transform.position =new Vector3 (point-15f,0,-10);
        }
        if (GameObject.Find("Main Camera").transform.position.x > point + 15f)
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(point + 15f, 0, -10);
        }
    }
}
