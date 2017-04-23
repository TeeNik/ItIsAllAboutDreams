using UnityEngine;
using System.Collections;
using System;

public class Lever : MonoBehaviour, IUseable {

    public GameObject door;

    public bool hasDoorAnimation;
    public bool destroyLever;

    public void Use()
    {
        if(door.tag == "Useable")
        {
            door.GetComponent<Door>().locked = false;
            door.GetComponent<IUseable>().Use();
        }
        else if(hasDoorAnimation)
            door.GetComponent<Animator>().SetTrigger("use");

        if (destroyLever)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("use");
        }

 
    }

    string IUseable.GetType()
    {
        return "Lever";
    }
}
