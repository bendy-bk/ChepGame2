using UnityEngine;

public class IdleState : IState
{
    float timeRandom;
    float timer;

    public void OnEnter(Enemy e)
    {     
        e.StopMoving();
        timer = 0;
        timeRandom = Random.Range(2f, 4f);
    }

    public void OnExecute(Enemy e)
    {
        timer += Time.deltaTime;

        if (timer > timeRandom)
        {
            e.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Enemy e)
    {

    }
}
