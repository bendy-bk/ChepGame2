using UnityEditor.AI;
using System.Diagnostics;
using UnityEngine;

public class RunState : State
{
    private float speed = 3f;
    public RunState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Run state");
        stateMachine.animator.Play("run");
    }
    public override void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            Vector3 move = new Vector3(moveInput, 0f, 0f) * speed * Time.deltaTime;
            stateMachine.transform.position += move;


            // left or right
            if (moveInput != 0)
                stateMachine.transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
    }
    public override void Exit() => UnityEngine.Debug.Log("Exit Run");
}

