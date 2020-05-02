using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    private HeroController heroController;

    private void Start()
    {
        heroController = GetComponent<HeroController>();
    }

    void Update()
    {
        score = (int)Math.Abs(transform.position.y - heroController.startPosition.y);
    }

    public int GetScore()
    {
        return score;
    }
}
