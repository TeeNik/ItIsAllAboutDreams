using UnityEngine;
using System.Collections;

public class ItemIndicator : MonoBehaviour {

    public GameObject itemIndicator;

    Equipment equip;
    Inventory inv;

    void Start()
    {
        equip = GetComponent<Equipment>();
        inv = GetComponent<Inventory>();
    }

    public void CheckUpdate()
    {
        
    }
}
