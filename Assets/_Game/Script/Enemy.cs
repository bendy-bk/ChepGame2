using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float attackRange;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;

    [SerializeField] private IState currentState;
    public bool isRight = true;
    private Character target;
    [SerializeField] private GameObject attackArea;

    public Character Target => target;


    private void Update()
    {
        if (currentState != null && !IsDead)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
        DeactiveAttack();
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(healthBars.gameObject);
        Destroy(gameObject);
    }
    protected override void OnDeadth()
    {
        base.OnDeadth();
        ChangeState(null);
        
    }
    public void Moving()
    {
        ChangeAnim("run");

        rb.velocity = transform.right * moveSpeed;

    }
    public void StopMoving()
    {
        ChangeAnim("idle");
        rb.velocity = Vector2.zero;
    }
    public void Attack()
    {
        ChangeAnim("attack");
        ActiveAttack();
        Invoke(nameof(DeactiveAttack), 0.5f);
    }
    public bool IsTargetRange()
    {
        if (target != null && Vector2.Distance(target.transform.position, transform.position) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWall")
        {
            ChangeDiraection(!isRight);
        }
    }

    public void ChangeDiraection(bool isRight)
    {
        this.isRight = isRight;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }

    internal void SetTarget(Character character)
    {
        this.target = character;
        if (IsTargetRange())
        {
            ChangeState(new AttackState());
        }
        else if (Target != null)
        {
            ChangeState(new PatrolState());
        }
        else
        {
            ChangeState(new IdleState());
        }
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }
    private void DeactiveAttack()
    {
        attackArea.SetActive(false);
    }
}
