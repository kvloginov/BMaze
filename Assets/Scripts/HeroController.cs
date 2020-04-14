﻿using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class HeroController : MonoBehaviour
{
    public float shiftSpeed;
    public float runSpeed;

    private Rigidbody2D rb;

    private Vector2 moveSpeed;
    private Vector2 heroPositionOnScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heroPositionOnScreen = GetHeroPositionOnScreen();
    }

    private  Vector2 GetHeroPositionOnScreen()
    {
        return Camera.main.WorldToScreenPoint(rb.position);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed.magnitude;
    }

    void Update()
    {
        heroPositionOnScreen = GetHeroPositionOnScreen();
        var input = TouchController.GetMoveVector(heroPositionOnScreen).normalized;

        moveSpeed = input * shiftSpeed + new Vector2(0, runSpeed);
    }
 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
    }
}
