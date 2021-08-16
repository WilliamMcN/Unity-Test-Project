using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour {
    public Object player;

    // Use this for initialization
    void Start () {
        Debug.Log("Spawning Player");
        Instantiate(player, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
