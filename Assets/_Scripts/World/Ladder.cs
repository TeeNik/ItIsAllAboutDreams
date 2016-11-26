using UnityEngine;
using System.Collections;
using System;

public class Ladder : MonoBehaviour/*, IUseable*/ {

    GameObject player;

    public GameObject upPlatform;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
    public void Use()
    {
        if (player.GetComponent<Player1Conroller>().onLadder)
        {
            UseLadder(false,1);            
        }
        else
        {
            UseLadder(true,0);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), upPlatform.GetComponent<Collider2D>(), true);
        }
    }

    private void UseLadder(bool onLadder, int gravity)
    {
       player.GetComponent<Player1Conroller>().onLadder = onLadder;
        player.GetComponent<Rigidbody2D>().gravityScale = gravity;
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            UseLadder(false, 1);
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), upPlatform.GetComponent<Collider2D>(), false);
        }
    }
}
