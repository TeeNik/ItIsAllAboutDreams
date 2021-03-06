﻿using UnityEngine;
using System.Collections;
using System;

public class MeleeAttack : MonoBehaviour {

    public BoxCollider2D collider;
    public int damage;

    Vector3 v;
    
    void Start()
    {
        v = collider.transform.position;
    }


    public void AttackMelee(int e)
    {
        collider.enabled = Convert.ToBoolean(e) ;
        //collider.transform.position = new Vector3(collider.transform.position.x + 0.01f, collider.transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && tag!= "Enemy")
        {
            other.GetComponent<Health>().TakeDamage(damage);
            
        }
        if (other.tag == "Player")
        {
            //other.GetComponent<Rigidbody2D>().AddForce( Vector2.right * 3000);
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" && tag != "Enemy")
        {
            other.GetComponent<Health>().TakeDamage(damage);

        }
        if (other.tag == "Player")
        {
            //other.GetComponent<Rigidbody2D>().AddForce( Vector2.right * 3000);
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
