using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] public Animator animator { get; private set; }
    private Dictionary<StateType, State> states;
    private State currentState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        states = new Dictionary<StateType, State>
        {
            { StateType.Idle, new IdleState(this) },
            { StateType.Run, new RunState(this) },
            { StateType.Attack, new AttackState(this) },
            { StateType.Throw, new ThrowState(this) },
            { StateType.Jump, new JumpState(this) }
        };

        ChangeState(StateType.Idle);
    }

    public void Update()
    {
        HandleMovementInput();

        currentState?.Update();
    }

    /// <summary>
    /// Đổi trạng thái của character
    /// </summary>
    /// <param name="newStateType"></param>
    public void ChangeState(StateType newStateType)
    {
        StartCoroutine(SmoothTransition(newStateType));
    }

    /// <summary>
    /// Coroutine between 2 state
    /// </summary>
    /// <param name="newStateType"></param>
    /// <returns></returns>
    public IEnumerator SmoothTransition(StateType newStateType)
    {
        if (currentState != null)
        {
            currentState.Exit();
            yield return new WaitForSeconds(0.1f);
        }

        currentState = states[newStateType];
        currentState.Enter();
    }
    /// <summary>
    /// 
    /// </summary>
    private void HandleMovementInput()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            if (!(currentState is RunState))
                ChangeState(StateType.Run);
        }
        else
        {
            if (currentState is RunState)
                ChangeState(StateType.Idle);
        }

        // Ưu tiên nhảy
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeState(StateType.Jump);

        // Ưu tiên Attack
        if (Input.GetKeyDown(KeyCode.A))
            ChangeState(StateType.Attack);

        // Ưu tiên Throw
        if (Input.GetKeyDown(KeyCode.T))
            ChangeState(StateType.Throw);
    }

}