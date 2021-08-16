using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Object : MonoBehaviour
{
    public Monster monster;
    public bool foundPlayer = false;
    void Start()
    {
        Debug.Log("I am alive");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            monster.foundPlayer(other.gameObject);
            Debug.Log("Hello Player");
            Debug.Log("I see: " + other.gameObject.name);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            monster.foundPlayer(other.gameObject);
            Debug.Log("Player Staying");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            monster.lostPlayer();
            Debug.Log("Player Leaving");
            
        }
    }
}
