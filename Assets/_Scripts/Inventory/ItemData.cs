using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

    public Item item;
    public int amount;
    public int slot;

    private Tooltip tooltip;
    private Vector2 offset;
    private Inventory inv;
    private SpellPanel spellPanel;

    void Awake()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        spellPanel = GameObject.Find("Inventory").GetComponent<SpellPanel>();
        amount = 1;
        tooltip = inv.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if(item != null)
        { 
            transform.SetParent(transform.parent.parent.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(item.Type == "Spell")
        {
            transform.SetParent(spellPanel.slots[slot].transform);
            transform.position = spellPanel.slots[slot].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        transform.SetParent(inv.slots[slot].transform);
        transform.position = inv.slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print(45);
        if (item != null && eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().Use(slot);
        }

        if (item != null)
        {
            offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
            transform.position = eventData.position - offset;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
