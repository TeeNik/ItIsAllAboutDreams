using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if(tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition + new Vector3(50,-60,0);
        }
    }

	public void Activate(Item i)
    {
        item = i;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=#0773f0><b>" + item.Title + "</b></color>\n\n" + item.Description + "";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
