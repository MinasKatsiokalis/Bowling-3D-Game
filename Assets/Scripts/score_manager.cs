using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class score_manager{
    public static int[] frameScore1 = new int[12];
    public static int[] frameScore2 = new int[12];
    public static int score1 = 0;
    public static int score2 = 0;

    public static void InitPlayerScore()
    {
        for (int i = 0; i < 12; i++){
            frameScore1[i] = 0;
            frameScore2[i] = 0;
        }
    }

    public static int GetScore(int player)
    {
        if (player == 1)
        {
            score1 = 0;
            for (int i = 0; i < 10; i++)
            {
                //Debug.Log(frameScore1[i]);
                score1 += frameScore1[i];
            }
            return score1;
        }
        else
        {
            score2 = 0;
            for (int i = 0; i < 10; i++)
            {
                //Debug.Log(frameScore2[i]);
                score2 += frameScore2[i];
            }
            return score2;
        }
    }

    public static void ShowScore()
    {
        for (int i = 0; i < 12; i++){
            game_manager.ShowBallsPoints(1, i);
            Debug.Log("Player 1 Frame: "+(i+1)+" points: "+frameScore1[i]);
        }
        for (int i = 0; i < 12; i++)
        {
            game_manager.ShowBallsPoints(2, i);
            Debug.Log("Player 2 Frame: "+(i+1)+" points: " +frameScore2[i]);
        }
    }

    public static void CalculateScore(int player)
    {
        int ball0_points;
        int ball1_points;
        int balls_points=0;
        int next_ball;

        for (int i = 0; i < game_manager.GetCurrentFrame(player); i++) {
            if (i <= 9)
            {
                //get points of ball for each frame
                ball0_points = game_manager.GetPlayersPoints(player, i, 0);
                ball1_points = game_manager.GetPlayersPoints(player, i, 1);

                //both balls have been droped
                if ((ball0_points != -1) && (ball1_points != -1))
                {
                    balls_points = ball0_points + ball1_points;
                    //spare
                    if (balls_points == 10)
                    {
                        //get next ball's points
                        next_ball = game_manager.GetPlayersPoints(player, (i + 1), 0);
                        if (next_ball == -1)
                        {
                            return;
                        }
                        balls_points += next_ball;
                    }
                }
                //strike
                else if ((ball0_points == 10) && (ball1_points == -1))
                {
                    balls_points = 10;
                    //get next ball's points
                    next_ball = game_manager.GetPlayersPoints(player, (i + 1), 0);
                    if (next_ball == -1)
                    {
                        return;
                    }
                    //strike again
                    else if (next_ball == 10)
                    {
                        balls_points += 10;
                        //get next ball's points
                        int next_next_ball = game_manager.GetPlayersPoints(player, (i + 2), 0);
                        if (next_next_ball == -1)
                        {
                            return;
                        }
                        balls_points += next_next_ball;
                    }
                    //just take the two next balls
                    else
                    {
                        if (game_manager.GetPlayersPoints(player, (i + 1), 1) == -1)
                        {
                            return;
                        }
                        balls_points += (game_manager.GetPlayersPoints(player, (i + 1), 0)
                                        + game_manager.GetPlayersPoints(player, (i + 1), 1));
                    }
                }
                else
                {
                    return;
                }

                //update the player's frame score
                if (player == 1)
                {
                    frameScore1[i] = balls_points;
                }
                else
                {
                    frameScore2[i] = balls_points;
                }
            }

        }   
    }
 
}
