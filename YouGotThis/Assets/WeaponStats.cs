using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public int weaponDamage;
    public Transform attackPoint;
    public float attackRange;
    public PlayerCombat pc;
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("Damage: " + weaponDamage);
        pc.SetWeapon(weaponDamage);
    }
    void Start()
    {
        Debug.Log("Before Damage: " + weaponDamage);
        pc.SetWeapon(weaponDamage);
        //StartCoroutine(weaponSet());
        
    }
   /* IEnumerator weaponSet()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Debug.Log(weaponDamage);
        pc.SetWeapon(weaponDamage);
        Debug.Log("After Damage: " + pc.weaponDamage);
        pc.weaponDamage = weaponDamage;
        Debug.Log("Set Damage: " + pc.weaponDamage);


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
