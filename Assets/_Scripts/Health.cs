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
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("damage");
    }

    public void SpendMana(float mana)
    {
        currentMana -= mana;
    }

   

}
