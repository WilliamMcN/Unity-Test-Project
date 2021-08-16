using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Ability", menuName = "Class/Ability")]
public class AbilityScriptable : ScriptableObject
{
    public string AbilityCode;
    public string description;
    public string itemName;
    public string Class;
    public int level;
    public int Damage;
    public int DamageMutiplier;
    public float cooldownTimer;
    public float activeTimer;
    public int manaCost; 
    public Sprite itemImage;
}
