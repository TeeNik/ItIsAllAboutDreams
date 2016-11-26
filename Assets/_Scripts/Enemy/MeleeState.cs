using UnityEngine;
using System.Collections;
using System;

public class MeleeState : IEnemyState
{

    float attackTimer;
    float attackCoolDown = 3;
    bool canAttack = true;

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Attack();
        if(!enemy.inMeleeRange)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


        if (attackTimer >= attackCoolDown)
        {
            canAttack = true;
            attackTimer = 0;
        }

        if(canAttack)
        {
            canAttack = false;
            enemy.GetComponent<Animator>().SetBool("isWalking", false);
            enemy.GetComponent<Animator>().SetTrigger("attack");
            
        }
    }
}
