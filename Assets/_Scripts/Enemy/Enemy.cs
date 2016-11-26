using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private IEnemyState currentState;

    public GameObject target { get; set; }

    public float meleeRange = 3;

    public float idleDuration;
    public float patrolDuration;

    public bool inMeleeRange
    {
        get
        {
            if (target != null)
            {
                return Vector2.Distance(transform.position, target.transform.position) <= meleeRange;
            }
            return false;
        }
    }

    public bool facingRight = true;
    public float speed;

    void Start()
    {
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState.Execute();
        LookAtTarger();
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    private void LookAtTarger()
    {
        if(target != null)
        {
            float x = target.transform.position.x - transform.position.x;
            if (x > 0 && facingRight || x < 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void Move()
    {
        GetComponent<Animator>().SetBool("isWalking", true);

        GetComponent<Rigidbody2D>().velocity = GetDirection() * speed;
    }

    public Vector2 GetDirection()
    {
        return !facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if(other.tag == "Sword")
        {
            GetComponent<Health>().TakeDamage(40);
            print(GetComponent<Health>().currentHealth);
        }*/
        
        currentState.OnTriggerEnter2D(other);
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    
}
