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


    public void CloseMenu()
    {
        mainMenuObject.SetActive(false);
    }

    public void InvokeMenu(int score) 
    {
        SetScoreText(score);
        mainMenuObject.SetActive(true);
    }

    private void SetScoreText(int score)
    {
        scoreText.text = "Your score: " + score;
    }
}
