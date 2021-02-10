using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball3_manager2 : MonoBehaviour
{

    Text instruction;
    // Use this for initialization
    void Start()
    {
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_manager.p2_points[11, 0] != -1)
        {
            if (game_manager.p2_points[11, 0] == 10)
                instruction.text = "X";
            else
                instruction.text = "" + game_manager.p2_points[11, 0];
        }
        else if (game_manager.p2_points[10, 1] != -1)
        {
            if (game_manager.p2_points[10, 0] + game_manager.p2_points[10, 1] == 10)
                instruction.text = "/";
            else
                instruction.text = "" + game_manager.p2_points[10, 1];
        }
        else if (game_manager.p2_points[10, 0] != -1 && game_manager.p2_points[9, 0] < 10 && game_manager.p2_points[9, 0] > -1)
        {
            if (game_manager.p2_points[10, 0] == 10)
                instruction.text = "X";
            else
                instruction.text = "" + game_manager.p2_points[10, 0];
        }
        else
            instruction.text = "";
    }
}
