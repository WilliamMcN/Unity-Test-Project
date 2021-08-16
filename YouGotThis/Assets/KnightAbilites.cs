using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnightAbilites : MonoBehaviour
{
    public Controls controller;
    public List<AbilityScriptable> AbilityCodes;
    public List<AbilityScriptable> SetAbilitles;
    public List<bool> Active;
    public List<float> Timers;
    public Abilities AbilityController;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active[0])
        {
            Timers[0] -= Time.deltaTime;
            //Debug.Log(Timers[0].Timers);
            if(Timers[0] <= 0)
            {
                Active[0] = false;
            }
        }
        if (Active[1])
        {
            Timers[1] -= Time.deltaTime;
            //Debug.Log(Timers[0].Timers);
            if (Timers[1] <= 0)
            {
                Active[1] = false;
            }
        }
        if (Input.GetKeyDown(controller.ab1)){
            if (SetAbilitles[0] == null)
            {
                Debug.Log("No Ability Selected");
            }
            else
            {
                if (Active[0])
                {
                    Debug.Log("Still on cooldown");
                }
                else
                {
                    Debug.Log("Ability 1");
                    Debug.Log(player.currentMana);
                    Debug.Log(SetAbilitles[0].manaCost);
                    if (player.currentMana < SetAbilitles[0].manaCost)
                    {
                        Debug.Log("Mana to low");
                    }
                    else
                    {
                        Timers[0] = SetAbilitles[0].cooldownTimer;
                        Active[0] = true;
                        player.UseMana(SetAbilitles[0].manaCost);
                        //player.currentMana = player.currentMana - SetAbilitles[0].manaCost;
                        AbilityController.RunAbility(SetAbilitles[0]);
                    }
                }
            }
        }
        if (Input.GetKeyDown(controller.ab2)){
            if (SetAbilitles[1] == null)
            {
                Debug.Log("No Ability Selected");
            }
            else
            {
                if (Active[1])
                {
                    Debug.Log("Still on cooldown");
                }
                else
                {
                    Debug.Log("Ability 1");
                    Debug.Log(player.currentMana);
                    Debug.Log(SetAbilitles[1].manaCost);
                    if (player.currentMana < SetAbilitles[1].manaCost)
                    {
                        Debug.Log("Mana to low");
                    }
                    else
                    {
                        Timers[1] = SetAbilitles[1].cooldownTimer;
                        Active[1] = true;
                        player.UseMana(SetAbilitles[1].manaCost);
                        //player.currentMana = player.currentMana - SetAbilitles[1].manaCost;
                        AbilityController.RunAbility(SetAbilitles[1]);
                    }
                }
            }
        }
        if (Input.GetKeyDown(controller.ab3)){
            if (SetAbilitles[2] == null)
            {
                Debug.Log("No Ability Selected");
            }
            else
            {
                if (Active[2])
                {
                    Debug.Log("Still on cooldown");
                }
                else
                {
                    Debug.Log("Ability 3");
                    Debug.Log(player.currentMana);
                    Debug.Log(SetAbilitles[2].manaCost);
                    if (player.currentMana < SetAbilitles[2].manaCost)
                    {
                        Debug.Log("Mana to low");
                    }
                    else
                    {
                        Timers[2] = SetAbilitles[2].cooldownTimer;
                        Active[2] = true;
                        player.UseMana(SetAbilitles[2].manaCost);
                        //player.currentMana = player.currentMana - SetAbilitles[0].manaCost;
                        AbilityController.RunAbility(SetAbilitles[2]);
                    }
                }
            }
        }
        if (Input.GetKeyDown(controller.ab4)){

        }
        if (Input.GetKeyDown(controller.ab5)){


        }
        if (Input.GetKeyDown(controller.ab6)){

        }
        if (Input.GetKeyDown(controller.ab7)){

        }
        if (Input.GetKeyDown(controller.ab8)){

        }
        if (Input.GetKeyDown(controller.ab9)){

        }
    }
    
}
