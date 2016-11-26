using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public int id;
    bool canPickUp;
    Item item;
    Vector3 labelPos;

    void Start()
    {
        item = GameObject.Find("Inventory").GetComponent<ItemDatabase>().FetchItemByID(id);
        GetComponent<SpriteRenderer>().sprite = item.Sprite;
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.F) && canPickUp)
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(id);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        labelPos = Camera.main.WorldToScreenPoint(transform.position);
        if (other.gameObject.tag == "Player")
            canPickUp = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            canPickUp = false;
    }

    void OnGUI()
    {
        if(canPickUp)
        {
            //transform.position            координаты объета перевести в координаты на экране и с помощью них задать координаты надписи
            GUI.Label(new Rect(labelPos.x, /*Screen.currentResolution.height - */labelPos.y, 100, 100), item.Title);
        }
        
    }
}
