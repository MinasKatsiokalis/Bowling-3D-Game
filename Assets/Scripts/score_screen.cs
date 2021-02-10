using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_screen : MonoBehaviour {
    Text instruction;
    // Use this for initialization
    void Start () {
        instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        instruction.text = ("Player 1: "+ score_manager.GetScore(1));
    }
}
