using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    bool paused;
    bool invOpen;

    public GameObject inventoryPanel;
    public GameObject tooltip;
    public GameObject spellPanel;

    void Start()
    {
        inventoryPanel.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Pause();
        OpenInventory();
        OpenSpells();
    }

    void Pause()
    {
            if (!paused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            paused = !paused;
    }

    void OpenInventory()
    {    
        if (Input.GetKeyDown(KeyCode.I))
        {

            if (invOpen)
            {
                inventoryPanel.SetActive(false);
                tooltip.SetActive(false);

                GameObject.Find("Inventory").GetComponent<Equipment>().ChangeRingsEnablity();
                    
            }

            else
            {
                inventoryPanel.SetActive(true);
                GameObject.Find("Inventory").GetComponent<Equipment>().ChangeRingsEnablity();
            }

            invOpen = !invOpen;
        }      
    }

    void OpenSpells()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {

            if (spellPanel.activeSelf)
            {
                spellPanel.SetActive(false);
                tooltip.SetActive(false);
            }

            else
            {
                spellPanel.SetActive(true);
            }
        }
    }


}
