using UnityEngine;
using System.Collections;

public class MoveSpikes : MonoBehaviour {

    public int damage = 30;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
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
