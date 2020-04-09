using System.Collections;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float GetMoveSpeed()
    {
        return moveSpeed.magnitude;
    }


    void Update()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveSpeed = input.normalized * shiftSpeed + new Vector2(0, runSpeed);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
    }
}
