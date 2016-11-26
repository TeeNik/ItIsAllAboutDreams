using UnityEngine;
using System.Collections;

public class AutoShot : MonoBehaviour {

    public GameObject shot;
    public Transform shotPoint;
    public Vector2 speed;
    public float frequency;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= frequency)
        {
            timer = 0;
            GameObject clone = Instantiate(shot, shotPoint.position, shotPoint.rotation) as GameObject;
            clone.GetComponent<ProjectileMover>().good = false;
            clone.GetComponent<ProjectileMover>().speed = speed;
        }
    }
}
