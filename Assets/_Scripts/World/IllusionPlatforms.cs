using UnityEngine;
using System.Collections;
using System;


public class IllusionPlatforms : MonoBehaviour, IUseable {

    public Collider2D collider;

    public void Use()
    {
        collider.enabled = true;
        GetComponent<CollisionTrigger>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
        Destroy(transform.GetChild(0).gameObject);
    }

    string IUseable.GetType()
    {
        return "Illusion";
    }

   
}
