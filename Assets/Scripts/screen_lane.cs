using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class screen_lane : MonoBehaviour {

    Text instruction;

    // Use this for initialization
    void Start () {
        instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        instruction.text = game_manager.ShowInfo("lane");
    }
}
