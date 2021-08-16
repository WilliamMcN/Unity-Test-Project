using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public PlayerCombat pc;
    public bool outOfAttack = true;
    public float setCount;
    public List<string> monsterNames;
    public bool alreadyHit = false;
    public int startOfList = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        setCount = pc.count;
    }

    // Update is called once per frame
    void Update()
    {
        //if pc.midAttack = false reset list of monsters
        if(pc.count == setCount)
        {
            alreadyHit = false;
            monsterNames.Clear();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pc.midAttack == true)
        {
            //Add gameObject.name(monster name) to list of monster
            Debug.Log(other.gameObject.name);
            Debug.Log("Player:" + pc.weaponDamage + "Weapon: " + pc.playerDamage);

            if (other.gameObject.layer == 8)
            {
                if (monsterNames.Count == 0)
                {
                    Debug.Log("Empty Array");
                    monsterNames.Add(other.gameObject.name);
                    other.GetComponent<Monster>().TakeDamage(pc.weaponDamage + pc.playerDamage);
                }
                else
                {
                    for (int i = 0; i < monsterNames.Count; i++)
                    {
                        Debug.Log("While");
                        if (monsterNames[i].Equals(other.gameObject.name))
                        {
                            Debug.Log("Compare");
                            alreadyHit = true;
                        }
                    }
                    if (alreadyHit == false)
                    {
                        other.GetComponent<Monster>().TakeDamage(pc.weaponDamage + pc.playerDamage);
                        monsterNames.Add(other.gameObject.name);
                    }

                }
            }
        }
    }

}
