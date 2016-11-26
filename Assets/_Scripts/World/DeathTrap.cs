using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1000);
        }
    }
}
