using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

	void Update () {
        destructuion();
    }
    void destructuion()
    {
        if (this.gameObject.transform.position.x+25.62f+15f<=GameObject.Find("Main Camera").GetComponent<Transform>().position.x)
        {
            GameObject.Find("Environment").GetComponent<BackrSpawner>().activeBox--;
            if (GameObject.Find("Environment").GetComponent<BackrSpawner>().bossRoom)
            {
                iniBossFight();
            }
            Destroy(this.gameObject);
        }
    }
    public void iniBossFight()
    {
        GameObject.Find("Main Camera").GetComponent<CameraController>().boss = true;
    }
}
