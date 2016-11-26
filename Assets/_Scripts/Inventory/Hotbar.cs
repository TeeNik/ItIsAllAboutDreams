using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour {

    GameObject hotbar;
    Inventory inv;
    GameObject slotPanel;

    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    //public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    public int[] nums;

    void Start()
    {
        slotAmount = 10;
        nums = new int[slotAmount];
        for (int i = 0; i < slotAmount; i++) nums[i] = -1;

        inv = GetComponent<Inventory>();
        hotbar = GameObject.Find("HotBar");
        slotPanel = hotbar.transform.FindChild("SlotPanel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }
    
    void Update()
    {
        UsingHotbar();
        CheckAll();

    }

    public int CheckIfIsInHotbar(int slot)
    {
        for(int i = 0; i < slotAmount; i++)
        {
            if (nums[i] == slot) return i;
        }
        return -1;
    }

    void CheckAll()
    {
        for (int i = 0; i < slotAmount; i++)
        {
            if(nums[i] != -1)
            {
                if (inv.slots[nums[i]].transform.childCount != 0)
                {
                    int amount = inv.slots[nums[i]].transform.GetChild(0).GetComponent<ItemData>().amount;


                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();

                    if (amount == 1)
                    {
                        data.transform.GetChild(0).GetComponent<Text>().text = "";
                    }
                    else
                    {
                        data.transform.GetChild(0).GetComponent<Text>().text = amount.ToString();
                    }
                }
            }
        }
    }

    public void RemoveFromHotbar(int slot)
    {
        nums[slot] = -1;
        string s = slots[slot].transform.GetChild(0).name;
        slots[slot].transform.GetChild(0).SetParent(transform.parent);
        Destroy(GameObject.Find(s));
    }

    void UsingHotbar()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && nums[0] != -1)
        {
            GetComponent<Inventory>().Use(nums[0]);
        }
    }
}
