using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {

    public Item head;
    public Item body;
    public Item weapon;
    public Item charm;
    public Item amulet;

    private PlayerHealth health;
    private Inventory inv;
    public GameObject checkRing;

    private List<GameObject> rings = new List<GameObject>();
    private int ringAmount;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        ringAmount = 4;

        for (int i = 0; i < ringAmount; i++)
        {
            rings.Add(Instantiate(checkRing));
            rings[i].transform.SetParent(GameObject.Find("Canvas").transform);
            rings[i].SetActive(false);
        }

    }


    public void EquipItem(Item item)
    {
        if (item.Type == "Weapon")
        {
            if(weapon != null) DecreaseStats(weapon);
            weapon = item;
            IncreaseStats(weapon);
        }
        else if (item.Type == "Head")
        {
            if (head != null) DecreaseStats(head);
            head = item;
            IncreaseStats(head);
        }
        else if (item.Type == "Body")
        {
            if (head != null) DecreaseStats(body);
            body = item;
            IncreaseStats(body);
        }
    }

    void IncreaseStats(Item item)
    {
        health.strength += item.Strength;
        health.stamina += item.Stamina;
        health.dexterity += item.Dexterity;
        health.intelligence += item.Intelligence;
    }

    void DecreaseStats(Item item)
    {
        health.strength -= item.Strength;
        health.stamina -= item.Stamina;
        health.dexterity -= item.Dexterity;
        health.intelligence -= item.Intelligence;
    }

    public void SetRing(int slot)
    {
        ItemData data = inv.slots[slot].transform.GetChild(0).GetComponent<ItemData>();

        if (data.item.Type == "Head")
        {
            rings[0].SetActive(true);
            rings[0].transform.position = inv.slots[slot].transform.position;
        }
        else if (data.item.Type == "Body")
        {
            rings[1].SetActive(true);
            rings[1].transform.position = inv.slots[slot].transform.position;
        }
        else if (data.item.Type == "Weapon")
        {
            rings[2].SetActive(true);
            rings[2].transform.position = inv.slots[slot].transform.position;
        }       
    }

    public void ChangeRingsEnablity()
    {
        for(int i = 0; i < rings.Count; i++)
        {
            rings[i].SetActive(!rings[i].activeSelf);
        }
    }
         
}
