using UnityEngine;
using System.Collections;

public class DialoguePoint : MonoBehaviour {

    public int dialogNumber;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(GameObject.Find("Inventory").GetComponent<Dialogue>().PlayDialog(dialogNumber));
            GetComponent<Collider2D>().enabled = false;
        }
    }
	
}
