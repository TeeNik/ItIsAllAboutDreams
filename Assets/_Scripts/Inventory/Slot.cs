using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private Inventory inv;
    private Hotbar hotbar;
    private SpellPanel spellPanel;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        hotbar = GameObject.Find("Inventory").GetComponent<Hotbar>();
        spellPanel = GameObject.Find("Inventory").GetComponent<SpellPanel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (transform.parent.parent.name == "HotBar")
        {
            int key = hotbar.CheckIfIsInHotbar(droppedItem.slot);  //whether another slot already contains this item

            if (key != -1) hotbar.RemoveFromHotbar(key);

            if (hotbar.nums[id] != -1)                 //whether there is another item in the slot
                hotbar.RemoveFromHotbar(id);

            GameObject clone = Instantiate(eventData.pointerDrag.gameObject);
            clone.transform.SetParent(hotbar.slots[id].transform);
            clone.transform.position = hotbar.slots[id].transform.position;
            hotbar.nums[id] = droppedItem.slot;
        }
        else if (transform.parent.parent.name == "SpellPanel")
        {
            eventData.pointerDrag.transform.SetParent(spellPanel.slots[eventData.pointerDrag.GetComponent<ItemData>().slot].transform);
        }
        else if(inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;

            int key = hotbar.CheckIfIsInHotbar(droppedItem.slot);
            if (key != -1)
            {
                hotbar.nums[key] = id;
            }
            droppedItem.slot = id;
        }
        else if(droppedItem.slot != id)
        {
            Transform item = transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(transform);
            droppedItem.transform.position = transform.position;

            inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }
}
