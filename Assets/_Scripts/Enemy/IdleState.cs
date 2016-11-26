using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState
{
    private Enemy enemy;
    private float idleTimer;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;

    }

    public void Execute()
    {
        Idle();

        if(enemy.target != null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    private void Idle()
    {
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        enemy.GetComponent<Animator>().SetBool("isWalking", false);

        idleTimer += Time.deltaTime;

        if(idleTimer >= enemy.idleDuration)
        {
            enemy.ChangeState(new PatrolState());
        }
    }
}
