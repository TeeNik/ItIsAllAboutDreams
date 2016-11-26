using UnityEngine;
using System.Collections;

public class BigPlate : MonoBehaviour {

    public GameObject spikes;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            spikes.SetActive(true);
            spikes.GetComponent<Collider2D>().enabled = true;
            StartCoroutine(CloseSpikes());
        }       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    IEnumerator CloseSpikes()
    {
        yield return new WaitForSeconds(1);
        spikes.GetComponent<Animator>().SetTrigger("use");
    }
}
