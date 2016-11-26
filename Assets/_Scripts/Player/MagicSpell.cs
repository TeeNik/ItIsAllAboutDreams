﻿using UnityEngine;
using System.Collections;

public class MagicSpell : MonoBehaviour {

    public Transform shotPoint;
    public GameObject fireball;
    public GameObject icicle;
    public GameObject heal;
    public GameObject tornado;


    void FixedUpdate()
    {
        if (GetComponent<Player1Conroller>().canMove)
        {
            Fireball();
            Heal();
            Icicle();
            Tornado();


        }
    }

    void Fireball()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject clone = Instantiate(fireball, shotPoint.position, shotPoint.rotation) as GameObject;
            clone.GetComponent<ProjectileMover>().good = true;
  
            ChooseDirection(clone);

            GetComponent<Animator>().SetTrigger("cast");
        }
    }

    void Heal()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject clone = Instantiate(heal, transform.position, transform.rotation) as GameObject;
            GetComponent<PlayerHealth>().currentHealth += 30;
            Destroy(clone, 0.7f);
        }        
    }

    void Icicle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject clone = Instantiate(icicle, shotPoint.position, shotPoint.rotation) as GameObject;
            clone.name = "Icicle";
 
            ChooseDirection(clone);
        }
    }

    void Tornado()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject clone = Instantiate(tornado, shotPoint.position, shotPoint.rotation) as GameObject;
            clone.name = "Tornado";

            ChooseDirection(clone);
        }      
    }

    public void ChooseDirection(GameObject clone)
    {
        if (GetComponent<Player1Conroller>().facingRight)
        {
            //clone.GetComponent<ProjectileMover>().speed = 5;
        }
        else
        {
            clone.GetComponent<ProjectileMover>().speed = -clone.GetComponent<ProjectileMover>().speed;
            clone.transform.Rotate(0, 180, 0);
        }
    }
}
