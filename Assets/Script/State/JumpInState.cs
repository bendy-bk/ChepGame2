using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class JumpInState : State
{
    private JumpState parent;
    public JumpInState(JumpState jumpS,StateMachine stateMachine) : base(stateMachine)
    {
        parent = jumpS;
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Jumpin state");
        stateMachine.animator.Play("jumpin");
        stateMachine.StartCoroutine(Transition());
    }
    public override void Update()
    {
        
    }
    public override void Exit() => UnityEngine.Debug.Log("Jumpin Run");

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(0.25f);
        parent.OnJumpInFinished();
    }
}

