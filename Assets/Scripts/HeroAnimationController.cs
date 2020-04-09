using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    public float multiplier;

    private Animator animator;
    private HeroController heroController;

    void Start()
    {
        animator = GetComponent<Animator>();
        heroController = GetComponent<HeroController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = heroController.GetMoveSpeed();

        animator.SetFloat("animSpeed", moveSpeed * multiplier);
    }
}
