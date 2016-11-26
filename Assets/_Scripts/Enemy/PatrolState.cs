using UnityEngine;
using System.Collections;
using System;

public class PatrolState : IEnemyState
{
    private Enemy enemy;

    float patrolTimer;


    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Patrol();

        enemy.Move();

        if(enemy.target != null && enemy.inMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Patrol()
    {
        

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= enemy.patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
