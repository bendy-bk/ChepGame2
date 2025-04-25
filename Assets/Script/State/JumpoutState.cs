using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class JumpoutState : State
{
    private JumpState parent;

    public JumpoutState(JumpState parent, StateMachine stateMachine) : base(stateMachine)
    {
        this.parent = parent;
    }

    public override void Enter()
    {
        stateMachine.animator.Play("jumpout");
        stateMachine.StartCoroutine(Transition());
    }
    public override void Update()
    {
        
    }
    public override void Exit() => UnityEngine.Debug.Log("Jumpout Run");
    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(0.2f);
        parent.OnJumpOutFinished();
    }
}

