using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TwinkleRing : MonoBehaviour {

    float min = 0;
    float max = 255;

    bool reverse = false;

    float t = 0;

    Image img;

    void Start()
    {
        img = GetComponent<Image>();       
    }

    void Update()
    {
            t += Time.deltaTime;
            if (t > 0.01)
            {
                if (!reverse)
                    img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - 0.01f);
                else
                    img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a + 0.01f);

                if (img.color.a <= 0 || img.color.a >= 1)
                {
                    reverse = !reverse;
                }

                t = 0;
            }
    }
}
