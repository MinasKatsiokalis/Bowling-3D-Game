using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class game_manager {
    public static int frame1 = 1;
    public static int frame2 = 1;
    public static int more_balls1 = 0;
    public static int more_balls2 = 0;
    public static int players;
    public static int player_no = 1;
    public static int[,] p1_points = new int[12,2];
    public static int[,] p2_points = new int[12,2];
    public static int angle_y = 0;
    public static int difficulty;
    public static bool endOfGame = false;

    public static void ShowBallsPoints(int player, int i)
    {
        if (player == 1) { 
            Debug.Log("Player 1 Frame: " + (i + 1) + "ball 0:" + p1_points[i, 0]);
            Debug.Log("Player 1 Frame: " + (i + 1) + "ball 1:" + p1_points[i, 1]);
        }
        else{
            Debug.Log("Player 2 Frame: " + (i + 1) + "ball 0:" + p2_points[i, 0]);
            Debug.Log("Player 2 Frame: " + (i + 1) + "ball 1:" + p2_points[i, 1]);
        }
    }
    
    public static int GetPlayersPoints(int player,int frame,int ball)
    {
        if(player == 1)
            return p1_points[frame,ball]; 
        else
            return p2_points[frame,ball];
    }

    public static int GetCurrentFrame(int player)
    {
        if (player_no == 1)
            return frame1;
        else
            return frame2;
    }

    private static void ChangePLayer()
    {
        if (players == 2){
            if (player_no == 1)
                player_no = 2;
            else if (player_no == 2)
                player_no = 1;
        }
        else if(players == 3)
        {
            if (player_no == 1)
            {
                player_no = 2;
                angle_y = UnityEngine.Random.Range(-difficulty, difficulty);
            }
            else if (player_no == 2){
                player_no = 1;}
        }    
        else
            player_no = 1;
    }

    public static string ShowInfo(string info)
    {
        if (info == "player"){
            if (player_no == 1){
                if(frame1 <= 9)
                    return ("Player: " + player_no + " Frame: " + frame1);
                else
                    return ("Player: " + player_no + " Frame: 10");
            }
            else{
                if (frame2 <= 9)
                    return ("Player: " + player_no + " Frame: " + frame2);
                else
                    return ("Player: " + player_no + " Frame: 10");
            }
        }
        else{
            if (player_no == 1){
                return ("Left Lane");
            }
            else{
                return ("Right Lane");
            }
        }
    }
    
    public static void InitScores()
    {
        for (int i = 0; i < 12; i++){
            for (int y = 0; y < 2; y++){
                p1_points[i, y] = -1;
                p2_points[i, y] = -1;
            }

        }
    }

    public static string SetStateOfLane(int ball, int pins_dropped, string lane)
    {
        //frames 1-9
        if ( ((lane == "lane1") && (frame1 <= 9)) || ((lane == "lane2") && (frame2 <= 9)) ){

            //Detect if drop ball on the wrong lane!
            if ((player_no == 1 && lane == "lane2") || (player_no == 2 && lane == "lane1")){
                return "wrong";
            }

            if (ball == 0){
                if (lane == "lane1"){
                    //strike on 1st ball
                    if (pins_dropped == 10){
                        p1_points[GetCurrentFrame(1)-1, 0] = 10;
                        score_manager.CalculateScore(1);
                        frame1++;
                        ChangePLayer();
                        return "reset";
                    }
                    //give 2nd ball
                    else{
                        p1_points[GetCurrentFrame(1) - 1, 0] = pins_dropped;
                        score_manager.CalculateScore(1);
                        return "ball_2";
                    }
                }
                else if (lane == "lane2"){
                    //strike on 1st ball
                    if (pins_dropped == 10){
                        p2_points[GetCurrentFrame(2) - 1, 0] = 10;
                        score_manager.CalculateScore(2);
                        frame2++;
                        ChangePLayer();
                        return "reset";
                    }
                    //give 2nd ball
                    else{
                        p2_points[GetCurrentFrame(2) - 1, 0] = pins_dropped;
                        score_manager.CalculateScore(2);
                        return "ball_2";
                    }
                }
                else{
                    score_manager.ShowScore();
                    return "end";
                }
            }
            //2nd ball drop 
            else
            {
                if (lane == "lane1"){
                    p1_points[GetCurrentFrame(1) - 1, 1] = pins_dropped;
                    score_manager.CalculateScore(1);
                    frame1++;
                }
                else if (lane == "lane2"){
                    p2_points[GetCurrentFrame(2) - 1, 1] = pins_dropped;
                    score_manager.CalculateScore(2);
                    frame2++;
                }
                ChangePLayer();
                return "reset";
            }
        }

        //frame 10
        else if( ((lane == "lane1") && (frame1 == 10)) || ((lane == "lane2") && (frame2 == 10)) ){
            //Detect if drop ball on the wrong lane!
            if ((player_no == 1 && lane == "lane2") || (player_no == 2 && lane == "lane1"))
            {
                return "wrong";
            }

            if (ball == 0){
                if (lane == "lane1"){
                    //strike on 1st ball
                    if (pins_dropped == 10){
                        p1_points[GetCurrentFrame(1) - 1, 0] = 10;
                        score_manager.CalculateScore(1);
                        frame1++;
                        more_balls1=2;
                        return "reset";
                    }
                    //give 2nd ball
                    else{
                        p1_points[GetCurrentFrame(1) - 1, 0] = pins_dropped;
                        score_manager.CalculateScore(1);
                        return "ball_2";
                    }
                }
                else if (lane == "lane2"){
                    //strike on 1st ball
                    if (pins_dropped == 10){
                        p2_points[GetCurrentFrame(2) - 1, 0] = 10;
                        score_manager.CalculateScore(2);
                        frame2++;
                        more_balls2=2;
                        return "reset";
                        
                    }
                    //give 2nd ball
                    else{
                        p2_points[GetCurrentFrame(2) - 1, 0] = pins_dropped;
                        score_manager.CalculateScore(2);
                        return "ball_2";
                    }
                }
                else{
                    return "end";
                }
            }
            //2nd ball drop
            else{
                if (lane == "lane1")
                {
                    //spare on 10th frame
                    if (p1_points[GetCurrentFrame(1) - 1, 0] + pins_dropped == 10)
                    {
                        p1_points[GetCurrentFrame(1) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(1);
                        frame1++;
                        more_balls1 = 1;
                        return "reset";
                    }
                    else
                    {
                        p1_points[GetCurrentFrame(1) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(1);
                        if (frame2 == 10)
                        {
                            ChangePLayer();
                            return "reset";
                        }
                        return "end";
                    }
                }
                else
                {
                    if (p2_points[GetCurrentFrame(2) - 1, 0] + pins_dropped == 10)
                    {
                        p2_points[GetCurrentFrame(2) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(2);
                        frame2++;
                        more_balls2 = 1;
                        return "reset";
                    }
                    else
                    {
                        p2_points[GetCurrentFrame(2) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(2);
                        return "end";
                    }
                }           
            }
        }

        //frames > 10 (in case of spare/strike in 10th frame)
        else if (((lane == "lane1") && (frame1 > 10)) || ((lane == "lane2") && (frame2 > 10)))
        {
            //Detect if drop ball on the wrong lane!
            if ((player_no == 1 && lane == "lane2") || (player_no == 2 && lane == "lane1"))
            {
                return "wrong";
            }

            if (more_balls1 > 0 || more_balls2 > 0)
            {
                if (ball == 0)
                {   
                    //strike on 1st ball
                    if (pins_dropped == 10)
                    {
                        if (lane == "lane1")
                        {
                            p1_points[GetCurrentFrame(1) - 1, 0] = 10;
                            score_manager.CalculateScore(1);
                            more_balls1--;
                            frame1++;
                            if (more_balls1 == 1)
                            {
                                return "reset";
                            }
                            else
                            {
                                if (frame2 == 10)
                                {
                                    ChangePLayer();
                                    return "reset";
                                }
                                score_manager.ShowScore();
                                return "end";
                            }  
                        }
                        else if (lane == "lane2")
                        {
                            p2_points[GetCurrentFrame(2) - 1, 0] = 10;
                            score_manager.CalculateScore(2);
                            more_balls2--;
                            frame2++;
                            if (more_balls2 == 1)
                            {
                                return "reset";
                            }
                            score_manager.ShowScore();
                            return "end";
                        }
                        else
                        {
                            Debug.Log("Error");
                            return "end";
                        }
                    }
                    //give 2nd ball
                    else
                    {
                        if (lane == "lane1")
                        {
                            p1_points[GetCurrentFrame(1) - 1, 0] = pins_dropped;
                            score_manager.CalculateScore(1);
                            more_balls1--;
                            if (more_balls1 == 1)
                            {
                                return "ball_2";
                            }
                            else
                            {
                                if (frame2 == 10)
                                {
                                    ChangePLayer();
                                    return "reset";
                                }
                                else
                                {
                                    score_manager.ShowScore();
                                    return "end";
                                }
                            }
                        }
                        else if (lane == "lane2")
                        {
                            p2_points[GetCurrentFrame(2) - 1, 0] = pins_dropped;
                            score_manager.CalculateScore(2);
                            more_balls2--;
                            if (more_balls2 == 1) { 
                                return "ball_2";
                            }
                            else { 
                                score_manager.ShowScore();
                                return "end";
                             
                            }
                        }
                        else
                        {
                            Debug.Log("Error");
                            return "end";
                        }
                    }
                }
                //2nd ball drop 
                else
                {
                    if (lane == "lane1"){
                        p1_points[GetCurrentFrame(1) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(1);
                        more_balls1--;
                        if (frame2 == 10){
                            ChangePLayer();
                            return "reset";
                        }
                        else{
                            score_manager.ShowScore();
                            return "end";
                        }
                    }
                    else if (lane == "lane2"){
                        p2_points[GetCurrentFrame(2) - 1, 1] = pins_dropped;
                        score_manager.CalculateScore(2);
                        more_balls2--;
                        score_manager.ShowScore();
                        return "end";
                    }
                    else{
                        Debug.Log("Error");
                        return "end";
                    }
                }
            }
            else{
                score_manager.ShowScore();
                return "end";
            }
        }
        //end of all frames
        else{
            score_manager.ShowScore();
            return "end";
        }
    }
}


    