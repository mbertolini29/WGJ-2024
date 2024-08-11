using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("me inicio?");
        Debug.Log(rb.velocity);
        Vector2 speed = rb.velocity.normalized;
        bool isWalking = speed.sqrMagnitude > 0;
        if (isWalking)
        {

            Debug.Log("me muevo");
            animator.SetFloat("speedX", speed.x);
            //animator.SetFloat("speedY", speed.y);
        }
        animator.SetBool("isWalking", isWalking);
    }   
}
