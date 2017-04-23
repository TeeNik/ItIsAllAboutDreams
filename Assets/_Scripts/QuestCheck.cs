using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheck : MonoBehaviour, IUseable
{
    public int quest;

    private GameObject inventory;

    public void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    public void Use()
    {
        switch(quest)
        {
            case 1: //Zool
                if(GameObject.Find("Inventory").GetComponent<Inventory>().GetMoney() > 4)
                {
                    StartCoroutine(inventory.GetComponent<Dialogue>().PlayDialog(4));
                    inventory.GetComponent<Inventory>().SpendMoney(4);
                    inventory.GetComponent<Inventory>().AddItem(20);
                }
                else if(inventory.GetComponent<AdditionalVariables>().zoolPlease == 3)
                {
                    StartCoroutine(inventory.GetComponent<Dialogue>().PlayDialog(5));
                    inventory.GetComponent<Inventory>().AddItem(20);
                }
                else
                {
                    StartCoroutine(inventory.GetComponent<Dialogue>().PlayDialog(3));
                    inventory.GetComponent<AdditionalVariables>().zoolPlease++;
                }
                break;
        }
          
    }

    string IUseable.GetType()
    {
        return "Quest";
    }
}
