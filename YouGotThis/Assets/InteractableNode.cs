using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNode : MonoBehaviour
{
    public Controls control;
    public List<Items> resource = new List<Items>();
    public bool insideNode = false;
    public float count = 1.5f;
    public int amountOfResource;
    public PlayerLevels playerLevel;
    public List<int> MiningChance = new List<int>();
    public List<GameObject> NodeObjects = new List<GameObject>();
    public float resetResource = 10.0f;
    public float setResource;
    public int expPerNode;

    private void OnTriggerEnter(Collider other)
    {
        insideNode = true;
        Debug.Log("Entering");
    }
    private void OnTriggerExit(Collider other)
    {
        insideNode = false;
        Debug.Log("Leaving");
    }
    // Start is called before the first frame update
    void Start()
    {
        setResource = resetResource;
    }

    // Update is called once per frame
    void Update()
    {
        if (insideNode)
        {
            if (Input.GetKey("e"))
            {
                //Debug.Log("Key is held");
                count -= Time.deltaTime;
                if (count < 0)
                {
                    if (amountOfResource >= 0)
                    {
                        if (playerLevel.MiningLevel >= MiningChance[amountOfResource])
                        {
                            Debug.Log("Got Ore");
                            Debug.Log("Found:" + resource[amountOfResource].itemName.ToString());
                            count = 1.5f;
                            amountOfResource--;
                            playerLevel.checkMiningExp(expPerNode);

                            //NodeObjects[amountOfResource].gameObject.SetActive(false);
                        }
                        else
                        {
                            int randomNum = Random.Range(1, MiningChance[amountOfResource]);
                            Debug.Log(randomNum.ToString());
                            if (playerLevel.MiningLevel >= randomNum)
                            {
                                Debug.Log("Got Ore");
                                Debug.Log("Found:" + resource[amountOfResource].itemName.ToString());
                                count = 1.5f;
                                amountOfResource--;
                                playerLevel.checkMiningExp(expPerNode);
                                //NodeObjects[amountOfResource].gameObject.SetActive(false);
                            }
                            else
                            {
                                count = 1.5f;
                                amountOfResource--;
                                Debug.Log("Lost Ore");
                                //NodeObjects[amountOfResource].gameObject.SetActive(false);
                            }
                        }
                        NodeObjects[amountOfResource + 1].gameObject.SetActive(false);
                    }
                    else
                    {
                        resetResource -= Time.deltaTime;
                        Debug.Log("Resource is Empty");
                        if (resetResource <= 0.0f)
                        {
                            amountOfResource = 2;
                            for (int i = 0; i < amountOfResource + 1; i++)
                            {
                                NodeObjects[i].gameObject.SetActive(true);
                            }
                            resetResource = setResource;
                            Debug.Log("Reset Complete");
                        }
                    }
                }

            }
            else
            {
                if (amountOfResource <= 0)
                {
                    resetResource -= Time.deltaTime;
                }
                if (resetResource <= 0.0f)
                {
                    amountOfResource = 2;
                    for (int i = 0; i < amountOfResource + 1; i++)
                    {
                        NodeObjects[i].gameObject.SetActive(true);
                    }
                    resetResource = setResource;
                    Debug.Log("Reset Complete");
                }
                count = 1.5f;
            }

        }
        else
        {
            if (amountOfResource <= 0)
            {
                resetResource -= Time.deltaTime;
            }
            if (resetResource <= 0.0f)
            {
                amountOfResource = 2;
                for (int i = 0; i < amountOfResource+1; i++)
                {
                    NodeObjects[i].gameObject.SetActive(true);
                }
                resetResource = setResource;
                Debug.Log("Reset Complete");
            }
        }
    }
}
