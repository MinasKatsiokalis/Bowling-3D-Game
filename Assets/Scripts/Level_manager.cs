using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Level_manager : MonoBehaviour {
    public Image img;
    public Button but0;
    public Button but1;
    public Button but2;

    public void DifficultyMenu()
    {
        but0.gameObject.SetActive(true);
        but1.gameObject.SetActive(true);
        but2.gameObject.SetActive(true);
        img.gameObject.SetActive(true);
    }

    public void LoadSceneAI(int difficulty)
    {
        print("AI");
        game_manager.players = 3;
        game_manager.difficulty = difficulty;
        SceneManager.LoadScene("bowling");
    }

    public void LoadScene1P()
    {
        print("1P");
        game_manager.players = 1;
        SceneManager.LoadScene("bowling");
    }

    public void LoadScene2P()
    {
        print("2P");
        game_manager.players = 2;
        SceneManager.LoadScene("bowling");
    }

    public void ExitGame()
    {
        print("Exit Game!");
        Application.Quit();
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        but0.gameObject.SetActive(false);
        but1.gameObject.SetActive(false);
        but2.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "menu" )
            Cursor.visible = true;
    }
}
