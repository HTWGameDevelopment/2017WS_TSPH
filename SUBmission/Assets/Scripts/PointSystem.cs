using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {
    public Text ziffer;
    public float dmgdone;
    public float dmgrecived;
    public float deaths;
    void Start () {
        dmgdone=0f;
        dmgrecived=0f;
        deaths = 0f;
}
	
	// Update is called once per frame
	void Update () {
        ziffer.text = (" Dmg Done:"+dmgdone.ToString()+" Dmg Recived:"+dmgrecived.ToString()+" Deaths:"+deaths.ToString()+" Distance:"+GameObject.Find("Main Camera").GetComponent<Transform>().position.x.ToString());
    }
}
