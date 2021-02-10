using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball2_manager2 : MonoBehaviour
{
    Text instruction;
    string parent_name;
    // Use this for initialization
    void Start()
    {
        instruction = GetComponent<Text>();
        parent_name = transform.parent.name;
    }

    // Update is called once per frame
    void Update()
    {
        switch (parent_name)
        {
            case ("Frame1"):
                if (game_manager.p2_points[0, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[0, 1] == 10 || (game_manager.p2_points[0, 0] + game_manager.p2_points[0, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[0, 1];
                break;
            case ("Frame2"):
                if (game_manager.p2_points[1, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[1, 1] == 10 || (game_manager.p2_points[1, 0] + game_manager.p2_points[1, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[1, 1];
                break;
            case ("Frame3"):
                if (game_manager.p2_points[2, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[2, 1] == 10 || (game_manager.p2_points[2, 0] + game_manager.p2_points[2, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[2, 1];
                break;
            case ("Frame4"):
                if (game_manager.p2_points[3, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[3, 1] == 10 || (game_manager.p2_points[3, 0] + game_manager.p2_points[3, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[3, 1];
                break;
            case ("Frame5"):
                if (game_manager.p2_points[4, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[4, 1] == 10 || (game_manager.p2_points[4, 0] + game_manager.p2_points[4, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[4, 1];
                break;
            case ("Frame6"):
                if (game_manager.p2_points[5, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[5, 1] == 10 || (game_manager.p2_points[5, 0] + game_manager.p2_points[5, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[5, 1];
                break;
            case ("Frame7"):
                if (game_manager.p2_points[6, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[6, 1] == 10 || (game_manager.p2_points[6, 0] + game_manager.p2_points[6, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[6, 1];
                break;
            case ("Frame8"):
                if (game_manager.p2_points[7, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[7, 1] == 10 || (game_manager.p2_points[7, 0] + game_manager.p2_points[7, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[7, 1];
                break;
            case ("Frame9"):
                if (game_manager.p2_points[8, 1] == -1)
                    instruction.text = "";
                else if (game_manager.p2_points[8, 1] == 10 || (game_manager.p2_points[8, 0] + game_manager.p2_points[8, 1] == 10))
                    instruction.text = "/";
                else
                    instruction.text = "" + game_manager.p2_points[8, 1];
                break;
            case ("Frame10"):
                if (game_manager.p2_points[9, 1] != -1 && game_manager.p2_points[9, 0] != -1)
                {
                    if (game_manager.p2_points[9, 0] + game_manager.p2_points[9, 1] == 10)
                        instruction.text = "/";
                    else
                        instruction.text = "" + game_manager.p2_points[9, 1];
                }
                else if (game_manager.p2_points[10, 0] != -1)
                {
                    if (game_manager.p2_points[10, 0] == 10)
                        instruction.text = "X";
                    else
                        instruction.text = "" + game_manager.p2_points[10, 0];
                }
                else
                    instruction.text = "";
                break;
        }

    }
}

