using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth;
    public float maxMana;

    public float currentHealth;
    public float currentMana;

    public bool immortal = false;
    public float immortalTime;
    public int strength;
    public int intelligence;
    public int stamina;
    public int charism;
    public int dexterity;
    public int gamingSkills;

    public Image healthBar;
    public Image manaBar;

    public bool isDead
    {
        get
        {
            return (currentHealth <= 0);
        }
    }



    void Start()
    {
        maxHealth = 100;
        maxMana = 100;
        currentHealth = maxHealth;
        currentMana = maxMana;

        currentHealth = 60; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        currentMana = 60;
    }

    void FixedUpdate()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentMana > maxMana) currentMana = maxMana;

        if (isDead)
        {
            GetComponent<Animator>().SetTrigger("die");
        }

        healthBar.fillAmount = currentHealth / maxHealth;
        manaBar.fillAmount = currentMana / maxMana;   

    }

    public bool CheckMana(float f)
    {
        if (currentMana >= f) return true;
        else return false;
    }

    public void TakeDamage(float damage)
    {
        if (!immortal)
        {
            currentHealth -= damage;
            if (!isDead)
            {             
                GetComponent<Animator>().SetTrigger("damage");
                StartCoroutine(SetImmortal(immortalTime));
                StartCoroutine(Blink());
            }
            else
            {
                GetComponent<Animator>().SetTrigger("die");
            }
        }

    }

    IEnumerator SetImmortal(float time)
    {
        immortal = true;
        yield return new WaitForSeconds(time);
        immortal = false;
    }

    IEnumerator Blink()
    {
        while(immortal)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }   
    }

    public void SpendMana(float mana)
    {
        currentMana -= mana;
    }

}
