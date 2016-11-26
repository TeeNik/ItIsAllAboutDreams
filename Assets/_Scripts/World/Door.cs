using UnityEngine;
using System.Collections;
using System;

public class Door : MonoBehaviour, IUseable {

    public Collider2D col;

    public bool locked; 

    public void Use()
    {
        if(!locked)
        {
            col.enabled = !col.enabled;
            GetComponent<Animator>().SetTrigger("use");
        }      
    }

    string IUseable.GetType()
    {
        return "Door";
    }

}
