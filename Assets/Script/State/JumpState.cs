using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System;

public class JumpState : State
{
    private State currentJumpSubState;
    private JumpInState jumpIn;
    private JumpingState jumping;
    private JumpoutState jumpOut;

    public JumpState(StateMachine stateMachine) : base(stateMachine)
    {
        jumpIn = new JumpInState(this, stateMachine);
        jumping = new JumpingState(this, stateMachine);
        jumpOut = new JumpoutState(this, stateMachine);
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("JumpState Enter");
        ChangeSubState(jumpIn);
    }
    public override void Update()
    {
        /// Xử lý logic khi dang nhay
        currentJumpSubState?.Update();
    }
    public override void Exit()
    {
        currentJumpSubState?.Exit();
        UnityEngine.Debug.Log("JumpState Exit");
    }

    public void ChangeSubState(State newState)
    {
        currentJumpSubState?.Exit();
        currentJumpSubState = newState;
        currentJumpSubState.Enter();
    }

    internal void OnJumpInFinished()
    {
        ChangeSubState(jumping);
    }

    internal void OnJumpingFinished()
    {
        ChangeSubState(jumpOut);
    }

    internal void OnJumpOutFinished()
    {
        if (IsMovingHorizontally())
            stateMachine.ChangeState(StateType.Run);
        else
            stateMachine.ChangeState(StateType.Idle);
    }

    private bool IsMovingHorizontally()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f;
    }
}

