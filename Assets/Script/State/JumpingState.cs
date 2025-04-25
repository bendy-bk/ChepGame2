using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;
using System;

public class JumpingState : State
{
    private JumpState parent;
    private Rigidbody2D rb;
    private bool hasJumped = false;
    private float jumpForce = 7f;
    public JumpingState(JumpState parent, StateMachine stateMachine) : base(stateMachine)
    {
        this.parent = parent;
    }

    public override void Enter()
    {
        rb = stateMachine.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            UnityEngine.Debug.LogError("Rigidbody2D is null! Make sure Rigidbody2D is attached to the GameObject.");
            return; // Nếu không có Rigidbody, dừng lại để tránh lỗi.
        }
        UnityEngine.Debug.Log("Jumping state");
        stateMachine.animator.Play("jumping");

        if (!hasJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasJumped = true;
        }
    }
    public override void Update()
    {
        UnityEngine.Debug.Log(IsGrounded());
        if (rb.velocity.y <= 0 && IsGrounded())
        {
            parent.OnJumpingFinished();
            hasJumped = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.Raycast(stateMachine.transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }

    public override void Exit() => UnityEngine.Debug.Log("Jumping Run");
}

