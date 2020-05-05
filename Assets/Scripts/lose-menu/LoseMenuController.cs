using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseMenuController : MonoBehaviour
{

    public GameObject mainMenuObject;
    public Text scoreText;

    public void Start()
    {
        // не показываем менюшку в начале игры
        CloseMenu();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void CloseMenu()
    {
        mainMenuObject.SetActive(false);
        // хацк
        Time.timeScale = 1;
    }

    public void InvokeMenu(int score) 
    {
        // хацк
        Time.timeScale = 0;
        SetScoreText(score);
        mainMenuObject.SetActive(true);
    }

    private void SetScoreText(int score)
    {
        scoreText.text = "Your score: " + score;
    }
}
