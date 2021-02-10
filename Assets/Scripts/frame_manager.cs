using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frame_manager : MonoBehaviour
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
                if (game_manager.p1_points[0, 0] == 0 && game_manager.p1_points[0, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[0] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + score_manager.frameScore1[0];
                break;
            case ("Frame2"):
                if (game_manager.p1_points[1, 0] == 0 && game_manager.p1_points[1, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[1] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame3"):
                if (game_manager.p1_points[2, 0] == 0 && game_manager.p1_points[2, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[2] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[2] + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame4"):
                if (game_manager.p1_points[3, 0] == 0 && game_manager.p1_points[3, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[3] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame5"):
                if (game_manager.p1_points[4, 0] == 0 && game_manager.p1_points[4, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[4] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[4] + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame6"):
                if (game_manager.p1_points[5, 0] == 0 && game_manager.p1_points[5, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[5] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[5] + score_manager.frameScore1[4]
                        + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame7"):
                if (game_manager.p1_points[6, 0] == 0 && game_manager.p1_points[6, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[6] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[6] + score_manager.frameScore1[5] + score_manager.frameScore1[4]
                        + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame8"):
                if (game_manager.p1_points[7, 0] == 0 && game_manager.p1_points[7, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[7] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[7] + score_manager.frameScore1[6]
                        + score_manager.frameScore1[5] + score_manager.frameScore1[4]
                        + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame9"):
                if (game_manager.p1_points[8, 0] == 0 && game_manager.p1_points[8, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[8] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[8] + score_manager.frameScore1[7] + score_manager.frameScore1[6]
                        + score_manager.frameScore1[5] + score_manager.frameScore1[4]
                        + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
            case ("Frame10"):
                if (game_manager.p1_points[9, 0] == 0 && game_manager.p1_points[9, 1] == 0)
                    instruction.text = "0";
                else if (score_manager.frameScore1[9] == 0)
                    instruction.text = "";
                else
                    instruction.text = "" + (score_manager.frameScore1[9] + score_manager.frameScore1[8]
                        + score_manager.frameScore1[7] + score_manager.frameScore1[6]
                        + score_manager.frameScore1[5] + score_manager.frameScore1[4]
                        + score_manager.frameScore1[3] + score_manager.frameScore1[2]
                        + score_manager.frameScore1[1] + score_manager.frameScore1[0]);
                break;
        }
    }
}
