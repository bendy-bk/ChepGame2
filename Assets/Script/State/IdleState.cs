using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;

public class IdleState : State
{
    public IdleState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Idle state");
        stateMachine.animator.Play("idle");
    }
    public override void Update()
    {      
    }
    public override void Exit()
    {
        UnityEngine.Debug.Log("Exit Idle");      
    }
}

