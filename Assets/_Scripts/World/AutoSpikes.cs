using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpikes : MonoBehaviour {

    public float interval = 1.5f;
    private float time = 0f;
    private bool enab = false;

	void Update () {
        time += Time.deltaTime;

        if(time > interval)
        {
            time = 0;
            enab = !enab;
            transform.GetChild(0).gameObject.SetActive(enab);       
        }
	}
}
