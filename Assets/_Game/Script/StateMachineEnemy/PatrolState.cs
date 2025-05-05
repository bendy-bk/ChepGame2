using UnityEngine;
public class PatrolState : IState
{
    float timeRandom;
    float timer;
    public void OnEnter(Enemy e)
    {
        timer = 0;
        timeRandom = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy e)
    {
        timer += Time.deltaTime;

        if (e.Target != null)
        {
            // doi huong sang player
            e.ChangeDiraection(e.Target.transform.position.x > e.transform.position.x);

            if (e.IsTargetRange())
            {
                e.ChangeState(new AttackState()); 
            } else
            {
                e.Moving();
            }
        } else
        {
            if (timer < timeRandom)
            {
                e.Moving();
            }
            else
            {
                e.ChangeState(new IdleState());
            }
        }

       
    }

    public void OnExit(Enemy e)
    {

    }
}
