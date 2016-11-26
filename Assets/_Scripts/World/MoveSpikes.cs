using UnityEngine;
using System.Collections;

public class MoveSpikes : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(30);
        }
    }

    void DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    void DisableSpikes()
    {
        gameObject.SetActive(false);
    }
}
