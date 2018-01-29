using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    public bool paused; 
	public Button resumeButton;

	// Use this for initialization
	void Start () {
        paused = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
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
		resumeButton.onClick.AddListener (resumeButton_Click);

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

	public void resumeButton_Click(){

		GameObject.Find("Ui Camera/HUD/PausePanel").SetActive(false);
		paused = false;
	
	}

}
