using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public int playerDamage = 1;

    public int weaponDamage = 0;
    public float attackRange;
    public Transform attackPoint;

    public bool midAttack = false;
    public float count = 2.5f;


    public LayerMask enemyLayers;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Start: " + weaponDamage);
    }
    void Update()
    {
        Combat();
        if (midAttack)
        {
            count -= Time.deltaTime;
        }
        if (count <= 0)
        {
            midAttack = false;
            count = 2.5f;
        }
    }
    public void Combat()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (midAttack)
            {

            }
            else
            {
                //pc.Attack();
                anim.SetTrigger("Attack");
                midAttack = true;
            }

        }
    }

    

    // Update is called once per frame
    public void Attack()
    {
        //Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

       // foreach (Collider enemy in hitEnemies)
        //{
        //    Debug.Log("We hit " + enemy.name + " for: " + (weaponDamage + playerDamage));
            
          //  enemy.GetComponent<Monster>().TakeDamage(weaponDamage + playerDamage);
       // }


    }

    public void SetWeapon(int newWeaponDamage)
    {
        Debug.Log(newWeaponDamage);
        this.weaponDamage = newWeaponDamage;
        Debug.Log(weaponDamage);
    }
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
