using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	void DestroyObj(float t = 0)
    {
        Destroy(gameObject, t);
    }
}
