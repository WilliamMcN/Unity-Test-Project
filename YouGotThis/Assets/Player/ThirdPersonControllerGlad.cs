using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControllerGlad : MonoBehaviour
{
    public float Speed;


    // Update is called once per frame
    void Update()
    {
        Playermovement();
    }
    void Playermovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playermovement = new Vector3(hor,-ver , 0f) * Speed * Time.deltaTime;
        transform.Translate(playermovement, Space.Self);
    }
}
