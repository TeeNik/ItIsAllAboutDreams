using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SmallPlate : MonoBehaviour {

    public GameObject shot;
    public Vector2 speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject clone = Instantiate(shot, transform.GetChild(0).position, transform.GetChild(0).rotation) as GameObject;
            clone.GetComponent<ProjectileMover>().good = false;
            clone.GetComponent<ProjectileMover>().speed = speed;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
