using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] protected HealthBar healthBars;
    [SerializeField] protected CombatText conbatTextPrefap;


    private float hp;
    public bool IsDead => hp <= 0;
    private string currentAnim;

    /// Overide

    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
        healthBars.Init(100, transform);
    }
    public virtual void OnDespawn()
    {
        Destroy(gameObject);
    }
    protected virtual void OnDeadth()
    {
        ChangeAnim("dead");
        Invoke(nameof(OnDespawn), 2f);
    }


    /// public
    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;

            if (IsDead)
            {
                hp = 0;
                OnDeadth();
            }
            healthBars.SetNewHp(hp);
            Instantiate(conbatTextPrefap, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            animator.ResetTrigger(animName);
            currentAnim = animName;
            animator.SetTrigger(currentAnim);
        }
    }

}
