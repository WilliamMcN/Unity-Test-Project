using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterStomp : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 forwardPos;
    public bool Active;
    public float count;
    public AbilityScriptable ability;
    public int speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            count -= Time.deltaTime;
            transform.position += forwardPos * Time.deltaTime * speed;
            if (count <= 0)
            {
                Active = false;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Add gameObject.name(monster name) to list of monster
        Debug.Log(other.gameObject.name);
        Debug.Log(other.gameObject.layer);
        //Debug.Log("Player:" + player.weaponDamage + "Weapon: " + pc.playerDamage);
        if (other.gameObject.layer == 8)
        {
            Debug.Log(other.gameObject.layer);
            other.GetComponent<Monster>().TakeDamage(ability.Damage);
        }
    }
    private void OnEnable()
    {
        forwardPos = player.gameObject.transform.forward;
        gameObject.transform.position = player.gameObject.transform.position;
        gameObject.transform.rotation = player.gameObject.transform.rotation;
        count = ability.activeTimer;
        Active = true;
    }
}
