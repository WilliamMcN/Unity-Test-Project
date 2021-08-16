using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public List<AbilityScriptable> AbilityCodes;
    public List<GameObject> AbiliyObjects;

    public void RunAbility(AbilityScriptable AbilityCode)
    {
        if(AbilityCode.AbilityCode == "0001")
        {
            Debug.Log("Using: " + AbilityCode.itemName);
        }

        else if (AbilityCode.AbilityCode == "k0002")
        {
            Debug.Log("Using: " + AbilityCode.itemName);
            AbiliyObjects[1].SetActive(true);
        }
        else if (AbilityCode.AbilityCode == "k0003")
        {
            Debug.Log("Using: " + AbilityCode.itemName);
            AbiliyObjects[2].SetActive(true);
        }
    }
}
