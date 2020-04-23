using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    public ScoreController scoreController;
    public Text scoreText;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        int score = scoreController.GetScore();

        scoreText.text = $"Score: {score}";
    }
}
