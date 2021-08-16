using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int maxMana;
    public int currentMana;
    public KeyCode Damagecode;
    public KeyCode Manacode;

    public Heathbar healthbar;
    public Heathbar manabar;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        healthbar.SetMaxHeath(maxHealth);
        currentMana = maxMana;
        manabar.SetMaxHeath(maxMana);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Damagecode))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(Manacode))
        {
            UseMana(10);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHeath(currentHealth);
    }
   public void UseMana(int mana)
    {
        currentMana -= mana;
        manabar.SetHeath(currentMana);
    }
}
