using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {





	public GameObject consumable;

	// Use this for initialization
	void Start () {
		consumable.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		spawner();
	}
	public void spawner()
	{
		if(Random.Range(0f,1000f)<500f&&(!consumable.activeSelf || consumable.transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width, 0, 0)).x))
		{
			consumable.transform.position = new Vector3(x: (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)+2f, y: Random.Range(-4f, 4f), z: 0);
			consumable.SetActive(true);
		}
	}

}
