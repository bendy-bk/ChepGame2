using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class AttackState : IState
{
    float timer;
    public void OnEnter(Enemy e)
    {
        if(e.Target != null)
        {
            // Doi huong eney toi huong cua player
            e.ChangeDiraection(e.Target.transform.position.x > e.transform.position.x);

            e.StopMoving();
            e.Attack();
        }



    }

    public void OnExecute(Enemy e)
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            e.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Enemy e)
    {
       
    }
}
