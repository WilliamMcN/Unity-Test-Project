using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool moveable;
	public int maxHealth;
    public int currentHealth;
    public KeyCode Damagecode;
    public GameObject itemBox;
    GameObject itemBoxClone;
    public List<GameObject> itemBoxList = new List<GameObject>();
    public GameObject node;
    public SpawnerNode spawnNode;
    public Heathbar healthbar;
    public int amountofdrops;
    public List<Items> dropList = new List<Items>();
    public List<float> dropChance = new List<float>();
    public InteractableDrop rollDrop;
    public float maxDropRange;
    public Vector3 startingPosition;
    public Vector3 postiveZPosition;
    public Vector3 postiveXPosition;
    public Vector3 negativeZPosition;
    public Vector3 negativeXPosition;
    public Vector3 nodePosition;
    public float negativePos;
    public float postivePos;
    public int speed;
    public float movementChange = 0;
    public int whereToMove;
    public bool inMotion = false;
    public float idleCount = 2.0f;
    public bool toFar = false;
    public bool foundPlayerB = false;
    public GameObject playerGameObject;
    public bool ignorePlayer = false;
    public float ignoreTimer = 4.0f;
    public float stoppingDistance;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHeath(maxHealth);
        negativePos = spawnNode.negativeDist;
        postivePos = spawnNode.positiveDist;
        startingPosition = transform.position;
        nodePosition = node.transform.position;
        postiveZPosition = nodePosition + new Vector3(0, 0, postivePos);
        negativeZPosition = nodePosition + new Vector3(0, 0, negativePos);
        postiveXPosition = nodePosition + new Vector3(postivePos, 0, 0);
        negativeXPosition = nodePosition + new Vector3(negativePos, 0, 0);

    }
    public int getItem()
    {
        int selectedItem = 0;
        float randomNum = Random.Range(0f, maxDropRange);
        float total = 0;
        for (int i = 0; i < dropChance.Count; i++)
        {
            total = total + dropChance[i];
            if (randomNum < total)
            {
                selectedItem = i;
                i = dropChance.Count;
            }
        }
        Debug.Log("Item:" + dropList[selectedItem].itemName);
        return selectedItem;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Damagecode))
        {
            TakeDamage(10);
        }
        toFar = outOfBounds();
        if (ignorePlayer && moveable)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, (speed * 2) * Time.deltaTime);
            ignoreTimer -= Time.deltaTime;
            if(ignoreTimer <= 0)
            {
                ignorePlayer = false;
            }
        }
        if (toFar == false && ignorePlayer == false && moveable) 
        {
            ignoreTimer = 4.0f;
            if (foundPlayerB && toFar == false)
            {
                if (Vector3.Distance(transform.position, playerGameObject.transform.position) > stoppingDistance)
                {
                    Debug.Log(Vector3.Distance(transform.position, playerGameObject.transform.position));
                    transform.position = Vector3.MoveTowards(transform.position, playerGameObject.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                wandering();
            }
        }
        
    }
    public void foundPlayer(GameObject player)
    {
        if (moveable)
        {
            Debug.Log("Found player");
            playerGameObject = player;
            foundPlayerB = true;
        }
    }

    public void lostPlayer()
    {
        foundPlayerB = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Goblin Died");
            rollDrop.clear();
            int itemNum = 0;
            for (int i = 0; i < amountofdrops; i++)
            {
                itemNum = getItem();
                rollDrop.addItem(dropList[itemNum]);
            }
            Debug.Log("Calling items");
            rollDrop.callItems();
            //rollDrop.setColor();
            Debug.Log("Creating Clone");
            itemBoxClone = Instantiate(itemBox, transform.position, transform.rotation) as GameObject;
            Debug.Log("Kill Monster");
            gameObject.SetActive(false);
            
        }
        else
        {
            healthbar.SetHeath(currentHealth);
        }
    }
    public void wandering()
    {
        if (moveable)
        {
            if (movementChange > 0 && inMotion == true)
            {
                if (whereToMove == 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, postiveZPosition, speed * Time.deltaTime);
                }
                else if (whereToMove == 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, postiveXPosition, speed * Time.deltaTime);
                }
                else if (whereToMove == 3)
                {
                    transform.position = Vector3.MoveTowards(transform.position, negativeZPosition, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, negativeXPosition, speed * Time.deltaTime);
                }
                movementChange -= Time.deltaTime;
            }
            if (movementChange <= 0 && inMotion == false)
            {
                movementChange = Random.Range(2.0f, 6.0f);
                whereToMove = Random.Range(1, 4);
                inMotion = true;
                if (whereToMove == 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, postiveZPosition, speed * Time.deltaTime);
                }
                else if (whereToMove == 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, postiveXPosition, speed * Time.deltaTime);
                }
                else if (whereToMove == 3)
                {
                    transform.position = Vector3.MoveTowards(transform.position, negativeZPosition, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, negativeXPosition, speed * Time.deltaTime);
                }
            }
            if (movementChange <= 0 && inMotion == true)
            {
                idleCount -= Time.deltaTime;
                if (idleCount <= 0)
                {
                    inMotion = false;
                    idleCount = 2.0f;
                }
            }
        }
    }
        public bool outOfBounds()
        {
            if(transform.position.z < negativeZPosition.z || transform.position.x < negativeXPosition.x || transform.position.z > postiveZPosition.z || transform.position.x > postiveXPosition.x)
            {
                //Debug.Log("I am out of bounds");
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, (speed * 2) * Time.deltaTime);
            ignorePlayer = true;
            
                return true;
            }
        return false;

        }
    void OnDisable()
    {
        transform.position = startingPosition;
        currentHealth = maxHealth;
        healthbar.SetHeath(currentHealth);
        foundPlayerB = false;
    }



}
