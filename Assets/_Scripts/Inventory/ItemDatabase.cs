using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;



public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    private Equipment equipment;
    private GameObject player;
    private PlayerHealth playerHealth;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

        equipment = GetComponent<Equipment>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();          
    }

    public Item FetchItemByID(int id)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if (id == database[i].ID)
                return database[i];
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["strength"],(int)itemData[i]["stats"]["intelligence"],(int)itemData[i]["stats"]["stamina"], (int)itemData[i]["stats"]["dexterity"], itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString(), (int)itemData[i]["cost"], itemData[i]["type"].ToString()));
        }
    }

    public void Use(int id)
    {
        Item item = FetchItemByID(id);

        if(item.Type != "Consumable")
            equipment.EquipItem(item);


        switch (id)
        {
            case 10:
                {
                    playerHealth.currentHealth += item.Value;
                    break;
                }
            case 11:
                {
                    playerHealth.currentMana += item.Value;
                    break;
                }
            case 30:
                {
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, 8);

                    for (int i = 0; i < colliders.Length; i++)
                    {

                        if (colliders[i].gameObject.tag == "Useable" && colliders[i].gameObject.GetComponent<IUseable>().GetType() == "Illusion")
                        {
                            colliders[i].gameObject.GetComponent<IUseable>().Use();
                        }
                    }
                    break;
                }
        }
    }

}

public class Item
{
    private int v;
    private JsonData jsonData;

    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Stamina { get; set; }
    public int Dexterity { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public int Cost { get; set; }
    public string Type { get; set; }
    public Sprite Sprite { get; set; }


    public Item(int id, string title, int value,int strength, int intelligence, int stamina, int dexterity, string description, bool stackable, int rarity, string slug, int cost, string type) 
    {
        ID = id;
        Title = title;
        Value = value;
        Strength = strength;
        Intelligence = intelligence;
        Stamina = stamina;
        Dexterity = dexterity;
        Description = description;
        Stackable = stackable;
        Rarity = rarity;
        Slug = slug;
        Cost = cost;
        Type = type;
        Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        ID = -1;
    }
}
