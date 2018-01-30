using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
    public bool paused; 

	// Use this for initialization
	void Start () {
        paused = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        {
            if (!paused)
            {
                GameObject.Find("Ui Camera/HUD/PausePanel").SetActive(true);
                paused = true;
            }
            else
            {
                GameObject.Find("Ui Camera/HUD/PausePanel").SetActive(false);
                paused = false;
            }
        }
        pause(paused);
		
	}
    public void pause(bool pause)
    {
        if(pause)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
