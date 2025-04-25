using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;

public class AttackState : State
{
    public AttackState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Attack state");
    }
    public override void Update()
    {
    
    }
    public override void Exit() => UnityEngine.Debug.Log("Exit Attack");
}

