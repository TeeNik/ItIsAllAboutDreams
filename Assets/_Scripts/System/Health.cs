using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float maxHealth;
    public float maxMana;

    public float currentHealth;
    public float currentMana;

    public bool immortal = false;
    public float immortalTime;

    public bool isDead
    {
        get
        {
            return (currentHealth <= 0);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

 
    void FixedUpdate()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentMana > maxMana) currentMana = maxMana;

        if(isDead)
        {
            try
            {
                GetComponent<Animator>().SetTrigger("die");
            }
            catch(MissingComponentException)
            {
                //ну нет у него анимации, просто уничтоже его
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        try
        {
            GetComponent<Animator>().SetTrigger("damage");
        }
        catch(MissingComponentException)
        {
            //ничего страшного, если у него нет анимации
        }
    }

    public void SpendMana(float mana)
    {
        currentMana -= mana;
    }

   

}
