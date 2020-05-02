using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class HeroController : MonoBehaviour
{
    [Range(0, 10)]
    public float shiftSpeedX;
    [Range(0, 10)]
    public float shiftSpeedY;
    [Range(0, 10)]
    public float runSpeed;
    public Vector3 startPosition;


    private Rigidbody2D rb;

    private Vector2 moveSpeed;
    private Vector2 heroPositionOnScreen;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = startPosition;

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

        moveSpeed = new Vector2(input.x * shiftSpeedX, input.y * shiftSpeedY + runSpeed);
    }
 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
    }
}
