using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement vars")]
    [SerializeField] private float JumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private float JumpOffset;
    [SerializeField] private Transform GroundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = GroundColliderTransform.position;
       isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, JumpOffset, groundMask);
    }
    public void Move(float Direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            anim.SetTrigger("isJumping");
            Jump();
        }
        
        

        if (Mathf.Abs(Direction) > 0.01f)
        {
            HorizontalMovement(Direction);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        
    }
    private void HorizontalMovement(float Direction)
    {
        anim.SetBool("isRunning", true);
        rb.velocity = new Vector2(curve.Evaluate(Direction), rb.velocity.y);
    }
}
