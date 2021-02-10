using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_screen2 : MonoBehaviour {
    Text instruction;
    // Use this for initialization
    void Start () {
        instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (game_manager.players == 2)
            instruction.text = ("Player 2: " + score_manager.GetScore(2));
        else if (game_manager.players == 3)
            instruction.text = ("PlayerAI: " + score_manager.GetScore(2));
        else
            instruction.text = "";
    }
}
