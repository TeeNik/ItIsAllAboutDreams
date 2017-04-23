using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class Inventory : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 50;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        } 
        AddItem(20);
        AddItem(21);
        AddItem(22);
        AddItem(23);
        AddItem(24);
        AddItem(25);
        AddItem(26);
        AddItem(27);

        AddItem(2);
        AddItem(1);
        AddItem(3);
        AddItem(10);
        AddItem(10);
        AddItem(30);
        AddItem(60);
        AddItem(60);
        AddItem(60);
        AddItem(60);
        AddItem(60);
        AddItem(60);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if(itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    itemObj.transform.position = slots[i].transform.position;
                    break;
                }
            }
        }
        
    }

    public void RemoveItem(int slot, int num = 1)
    {
        ItemData it = slots[slot].transform.GetChild(0).GetComponent<ItemData>();
        if (slots[slot].transform.GetChild(0).GetComponent<ItemData>().amount == 1)
        {
            items[slot] = new Item();
            string s = slots[slot].transform.GetChild(0).name;
            slots[slot].transform.GetChild(0).SetParent(transform.parent);
            Destroy(GameObject.Find(s));

            int key = GetComponent<Hotbar>().CheckIfIsInHotbar(slot);
            if (key != -1)
            {
                GetComponent<Hotbar>().RemoveFromHotbar(key);
            }
        }
        else
        {
            it.amount -= num;
            if(it.amount == 1)
                it.transform.GetChild(0).GetComponent<Text>().text = "";
            else
                it.transform.GetChild(0).GetComponent<Text>().text = it.amount.ToString();
        }
    }

    public void Use(int slot)
    {
        Item item = slots[slot].transform.GetChild(0).GetComponent<ItemData>().item;
        GetComponent<ItemDatabase>().Use(item.ID);
        if (item.Type == "Consumable")
            RemoveItem(slot);

        if (item.Type != "Consumable")
        {
            GetComponent<Equipment>().SetRing(slot);
        }
    }

    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }

    public int GetMoney()
    {
        for (int i = 0; i < slotAmount; ++i)
        {
            if (slots[i].transform.GetChild(0).GetComponent<ItemData>().item.ID == 60)
            {
                return slots[i].transform.GetChild(0).GetComponent<ItemData>().amount;
            }
        }

        return 0;
    }

    public void SpendMoney(int sum)
    {
        int slot = 0;
        for(int i = 0; i < slotAmount; ++i)
        {
            if (slots[i].transform.GetChild(0).GetComponent<ItemData>().item.ID == 60)
            {
                slot = i;
                break;
            }
        }

        RemoveItem(slot, sum);
    }



}
