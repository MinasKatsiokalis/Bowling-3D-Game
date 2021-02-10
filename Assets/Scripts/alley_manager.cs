using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alley_manager : MonoBehaviour {
    private GameObject ball_2;
    private pin[] pins;
    private player[] player1;
    public int counter,counter1,counter2,ball;
    public GameObject ball_prefab;
    public Transform ball_pos;
    public Transform main_cam;
    public Rigidbody pin_prefab;
    private Vector3[] pins_pos;
    public Transform all_pins;
    private pin[] pin_left;
    public string state;

    //counting pins for each drop of player
    private int CountPins(){
        GetPinsState();
        foreach (pin p in pins){
            if (p.isStanding == true){
                if (ball == 0) { counter1++; }
                else if (ball == 1) { counter2++; }
            }
            else{
                Destroy(p.gameObject);
            }
        }
        if (ball == 0) {
            counter1 = 10 - counter1;
           return counter1;
        }
        else// if (ball == 1) 
        {
            counter2 = (10 -counter1) - counter2;
            return counter2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball" || other.gameObject.name == "Ball(Clone)"){
            print("in_lane");
            player.ball_on_lane = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {   
        //chech when ball gets out of alley
        if(other.gameObject.name == "Ball" || other.gameObject.name == "Ball(Clone)"){
            print("next move");
            Invoke("NextAction",5);
        }
        //Destroy anything out of lane
        if (other.gameObject.name != "Player"){
            Destroy(other.gameObject);
        }
    }

    private void NextAction()
    {
        state = game_manager.SetStateOfLane(ball, CountPins(), "lane1");
        print(state);
        if (state == "reset"){
            ResetPins();
            GiveBall2();
            if(ball == 1){
                ChangeBall();
            }
        }
        else if(state == "ball_2"){
            GiveBall2();
            ChangeBall();
        }
        else if (state == "wrong"){
            ResetPins();
            GiveBall2();
        }
        else{
            ResetPins();
            game_manager.endOfGame = true;
        }
    }

    //a simple function to get the pins
    private void GetPinsState(){
        pins = GetComponentsInChildren<pin>();
    }

    private void ChangeBall(){
        if(ball == 0) { ball = 1; }
        else if (ball ==1) { ball = 0; }
    }

    //give the 2nd ball to each player for his 2nd drop
    public void GiveBall2(){
        ball_2 = Instantiate(ball_prefab, ball_pos.position, ball_pos.rotation);
        ball_2.transform.SetParent(main_cam);

        player1 = FindObjectsOfType<player>();
        player1[0].have_ball = true;
        player.ball_on_lane = false;
        player1[0].ball = ball_2;
        player1[0].ball_rigid = ball_2.GetComponent<Rigidbody>();
        player1[0].ball_colider = ball_2.GetComponent<SphereCollider>();
    }


    //reset the pins after each player's turn
    private void ResetPins(){
        pin_left = GetComponentsInChildren<pin>();
        foreach (pin p in pin_left){
            Destroy(p.gameObject);
        }

        Rigidbody[] pins_rigid = new Rigidbody[10];
        for (int i = 0; i <= 9; i++){
            pins_rigid[i] = Instantiate(pin_prefab, all_pins.position, all_pins.rotation) as Rigidbody;
            pins_rigid[i].transform.Translate(pins_pos[i]);
            pins_rigid[i].transform.SetParent(all_pins);
        }
        counter = 0;
        counter1 = 0;
        counter2 = 0;
    }

    // Use this for initialization
    void Start () {
        counter = 0;
        counter1 = 0;
        counter2 = 0;
        ball = 0;
        game_manager.InitScores();
        score_manager.InitPlayerScore();
        game_manager.frame1 = 1;
        game_manager.frame2 = 1;
        game_manager.more_balls1 = 0;
        game_manager.more_balls2 = 0;
        game_manager.player_no = 1;
        score_manager.score1 = 0;
        score_manager.score2 = 0;
        game_manager.endOfGame = false;
        pins_pos = new Vector3[10];

        pins_pos[0].x = (float)-0.157; pins_pos[0].y = (float)-1.237; pins_pos[0].z = (float)-0.179;
        pins_pos[1].x = (float)-0.452; pins_pos[1].y = (float)-1.237; pins_pos[1].z = (float)-0.179;
        pins_pos[2].x = (float)-0.795; pins_pos[2].y = (float)-1.237; pins_pos[2].z = (float)-0.179;
        pins_pos[3].x = (float)-1.099; pins_pos[3].y = (float)-1.237; pins_pos[3].z = (float)-0.179;
        pins_pos[4].x = (float)-0.957; pins_pos[4].y = (float)-1.237; pins_pos[4].z = (float)-0.036;
        pins_pos[5].x = (float)-0.299; pins_pos[5].y = (float)-1.237; pins_pos[5].z = (float)-0.036;
        pins_pos[6].x = (float)-0.631; pins_pos[6].y = (float)-1.237; pins_pos[6].z = (float)-0.036;
        pins_pos[7].x = (float)-0.452; pins_pos[7].y = (float)-1.237; pins_pos[7].z = (float)0.121;
        pins_pos[8].x = (float)-0.795; pins_pos[8].y = (float)-1.237; pins_pos[8].z = (float)0.121;
        pins_pos[9].x = (float)-0.631; pins_pos[9].y = (float)-1.237; pins_pos[9].z = (float)0.267;
    }

    // Update is called once per frame
    void Update () {
    }
}
