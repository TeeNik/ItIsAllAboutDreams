using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectileMover : MonoBehaviour {

    //public float speed;
    public Vector2 speed;
    public int damage;

    Animator anim;

    bool shouldBeDestroy = true;
    int hits;


    public bool good; //true - belongs to player, harms enemies    false - hurts player, not enemies  
    
	void Awake()
    {
        anim = GetComponent<Animator>();
    }


	void Start () {
        GetComponent<Rigidbody2D>().velocity = speed;
       
        DestroyProjectile(5);
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !good)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            anim.SetTrigger("dead");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if (other.gameObject.tag == "Enemy" && good)
        {
            other.GetComponent<Health>().TakeDamage(damage);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            CastEffect(other.gameObject);

            if(shouldBeDestroy)
                anim.SetTrigger("dead");
        }
        else if(other.gameObject.tag == "Untagged")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anim.SetTrigger("dead");
        }
    }

    void DestroyProjectile(int time = 0)
    {       
        Destroy(gameObject, time);
    }

    void CastEffect(GameObject enemy)
    {     
        float chance = Random.Range(0f, 1f);
        if (name == "Icicle")
        {
            if (chance > 0.7)
            {
                enemy.GetComponent<SpriteRenderer>().color = Color.blue;
            }           
        }
        if(name == "Shock")
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != enemy.gameObject && colliders[i].gameObject.tag == "Enemy")
                {
                    shouldBeDestroy = false;
                }
            }
        }

        if(name == "Tornado")
        {
            if (hits < 2)
            {
                hits++;
                shouldBeDestroy = false;
            }
            else
            {
                hits = 0;
                shouldBeDestroy = true;
            }
        }
    }
}
