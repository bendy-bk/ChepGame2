using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface state of enemy
/// </summary>
public interface IState
{
    void OnEnter(Enemy e);
    void OnExecute(Enemy e);
    void OnExit(Enemy e);

}
