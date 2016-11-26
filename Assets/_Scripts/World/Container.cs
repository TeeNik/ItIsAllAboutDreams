using UnityEngine;
using System.Collections;
using System;

public class Container : MonoBehaviour, IUseable {

    public GameObject pickUp;

    public void Use()
    {
        if(pickUp != null)
            Instantiate(pickUp, transform.position, transform.rotation);

        GetComponent<Animator>().SetTrigger("use");
        GetComponent<Collider2D>().enabled = false;
        tag = "Untagged";
    }

    string IUseable.GetType()
    {
        return "Container";
    }
}
