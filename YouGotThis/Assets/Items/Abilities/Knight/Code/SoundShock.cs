using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundShock : MonoBehaviour
{
    public AbilityScriptable ability;
    public float count = 0.01f;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (count < time)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.layer == 8)
        {
            Debug.Log(other.gameObject.layer);
            other.GetComponent<Monster>().TakeDamage(ability.Damage);
        }
    }
}
