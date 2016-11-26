using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public GameObject pickUp;

	void Update()
    {
        if(GetComponent<Health>().isDead)
        {
            if (pickUp == null) return;
            Instantiate(pickUp, transform.position, transform.rotation);
            //GameObject.Find("Inventory").GetComponent<LevelLoader>().shouldBeDestroyed.Add(gameObject);
            Destroy(gameObject);
        }
    }
}
