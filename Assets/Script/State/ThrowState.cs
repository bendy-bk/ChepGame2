using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;

public class ThrowState : State
{
    public ThrowState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Run Throw");
    }
    public override void Update()
    {
    
    }
    public override void Exit() => UnityEngine.Debug.Log("Exit Throw");
}

