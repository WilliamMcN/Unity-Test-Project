using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCharacterController : MonoBehaviour {

    public float Speed;
    public Animator anim;
    public Text verText;
    public Rigidbody rb;
    public bool cubeIsOnTheGround = true;
    public PlayerCombat pc;
    public bool midAttack = false;
    public float count = 2.3f;

	// Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Update () {
        Playermovement();
       
    }
    void Playermovement() {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetFloat("vertical", ver);
        anim.SetFloat("horizontal", hor);
        verText.text = ver.ToString();
        Vector3 playermovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playermovement, Space.Self);

        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround == true)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
    }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Ground")
            {
                cubeIsOnTheGround = true;
            }
        }
    }

