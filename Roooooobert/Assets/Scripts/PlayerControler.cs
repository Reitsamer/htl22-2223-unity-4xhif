using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rigBody;
    private Animator animator;

    [SerializeField] 
    public Transform groundCheck;

    [SerializeField, Range(0, 2)] 
    private float groundCheckRadius;

    [SerializeField, Range(100,1000)]
    private int speed = 400;
    [SerializeField, Range(100, 1000)]
    private int jumpHight = 400;

    private float x;
    private float jump;

    private bool hasJumped = false;

    [SerializeField] 
    private LayerMask floorMask;

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //Movement
        //Left/Right
        x = Input.GetAxis("Horizontal");

        Vector2 currentScale = transform.localScale;

        if (x < 0)
        {
            currentScale.x = -1;
        }
        else if (x > 0)
        {
            currentScale.x = 1;
        }

        transform.localScale = currentScale;

        rigBody.velocity = Vector2.right * x * speed * Time.fixedDeltaTime;

        animator.SetInteger("Speed", Mathf.Abs(x) < 0.5 ? 0 : 1);

        //Jump
        jump = Input.GetAxis("Jump");
        

        if (IsGrounded)
        {
            rigBody.AddForce(Vector2.up * jump * jumpHight);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //TODO Check if on ground => reset hasJumped
        
    }

    void OnDrawGizmos()
    {
        Color color = Gizmos.color;
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
        Gizmos.color = color;
    }

    private bool IsGrounded
        => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, floorMask);
}
