using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public GameObject ball;
    public Rigidbody ball_rigid;
    public SphereCollider ball_colider;
    public float force;
    public bool have_ball;
    public static bool ball_on_lane;
    public Transform ball_pos;
    public Transform main_cam;
    public GameObject ball_prefab;
    public GameObject ball_2;
    public bool on_menu;
    public Image img;
    public Button but0;
    public Button but1;
    public Button but2;
    public Button but3;
    public AudioSource audio;
    public AudioClip sound;
    public Transform AI;
    public Transform player_pos;
    public bool AI_played;
    public bool P2_played;



    public void CheckBall(){
        print("check");
        if (!ball_on_lane && !have_ball)
        {   
            print("Ball out of lane");
            Destroy(ball);
            ReturnBall();
        }
    }

    public void ReturnBall(){
        ball_2 = Instantiate(ball_prefab, ball_pos.position, ball_pos.rotation);
        ball_2.transform.SetParent(main_cam);

        ball = ball_2;
        ball_rigid = ball_2.GetComponent<Rigidbody>();
        ball_colider = ball_2.GetComponent<SphereCollider>();
        have_ball = true;
        ball_on_lane = false;
        
    }

    public void throwBall()
    {
        ball_rigid.isKinematic = false;
        ball_rigid.useGravity = true;
        ball_rigid.AddForce(transform.forward * force);
        ball_colider.isTrigger = false;
        ball.transform.SetParent(null);
        have_ball = false;
        audio.PlayOneShot(sound);
        Invoke("CheckBall", 2);
    }

    // Use this for initialization
    void Start () {
		ball_rigid = ball.GetComponent<Rigidbody>();
		ball_colider = ball.GetComponent<SphereCollider>();
        have_ball = true;
        ball_on_lane = false;
        print("Players: "+game_manager.players);
        
        but0.gameObject.SetActive(false);
        but1.gameObject.SetActive(false);
        but2.gameObject.SetActive(false);
        but3.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        on_menu = false;
        audio = GetComponent<AudioSource>();
        AudioListener.volume = 1f;
        AI_played = false;
        P2_played = false;
    }

    // Update is called once per frame
    void Update() {
        if (on_menu)
        {
            //Do Nothing
            if (Input.GetKeyDown("escape"))
            {
                on_menu = !on_menu;
                but0.gameObject.SetActive(false);
                but1.gameObject.SetActive(false);
                but2.gameObject.SetActive(false);
                but3.gameObject.SetActive(false);
                img.gameObject.SetActive(false);
            }
        }
        else
        {   
            if (Input.GetKeyDown("escape"))
            {
                on_menu = !on_menu;
                but0.gameObject.SetActive(true);
                but1.gameObject.SetActive(true);
                but2.gameObject.SetActive(true);
                but3.gameObject.SetActive(true);
                img.gameObject.SetActive(true);
            }
            if (have_ball)
            {   
                if (game_manager.players == 3 && game_manager.player_no == 2)
                {
                    print("AI");
                    GetComponent<FirstPersonController>().enabled = false;
                    transform.SetPositionAndRotation(AI.position, AI.rotation);
                    transform.Rotate(0, game_manager.angle_y, 0);

                    throwBall();
                    AI_played = true;
                }
                else if (game_manager.players == 2 && game_manager.player_no == 2)
                {
                    print("P2..");
                    if (!P2_played)
                        transform.position = AI.position;

                    if (Input.GetMouseButtonDown(0))
                    {
                        throwBall();
                        
                    }
                    P2_played = true;

                }
                else
                {   
                    print("P1..");
                    if (AI_played)
                    {
                        transform.SetPositionAndRotation(player_pos.position, player_pos.rotation);
                        GetComponent<FirstPersonController>().enabled = true;
                        AI_played = false;
                    }
                    if (P2_played)
                    {
                        transform.position = player_pos.position;
                        P2_played = false;
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        throwBall();
                    }
                }
            }
            if (game_manager.endOfGame)
            {
                if (AI_played)
                {
                    GetComponent<FirstPersonController>().enabled = true;
                }
                if (Input.GetKeyDown("escape"))
                {
                    Cursor.visible = true;
                    SceneManager.LoadScene("menu");
                }
            }
        }
    }
}
