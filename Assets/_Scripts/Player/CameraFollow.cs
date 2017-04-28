using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;


    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;
    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    void Start()
    {

    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(bounds)
        {
            /*transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.y, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), 
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));*/
            if (transform.position.x < minCameraPos.x) transform.position = new Vector3(minCameraPos.x, transform.position.y, transform.position.z);
            if (transform.position.y < minCameraPos.y) transform.position = new Vector3(transform.position.x, minCameraPos.y, transform.position.z);

            if (transform.position.x > maxCameraPos.x) transform.position = new Vector3(maxCameraPos.x, transform.position.y, transform.position.z);
            if (transform.position.y > maxCameraPos.y) transform.position = new Vector3(transform.position.x, maxCameraPos.y, transform.position.z);
        }
    }
}
