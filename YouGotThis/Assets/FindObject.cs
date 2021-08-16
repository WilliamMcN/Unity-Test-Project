using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        Debug.Log("I see: " + other.gameObject.name);
    }
}
