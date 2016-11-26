using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dark : MonoBehaviour {

    SpriteRenderer sr;
    bool go = false;
    float t = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t > 0.01)
        {
            if (go)
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.02f);

            t = 0;
        }
    }

	void OnTriggerEnter2D(Collider2D other)
    {       
        if(other.tag == "Player")
        {
            go = true;          
        }
    }
}
