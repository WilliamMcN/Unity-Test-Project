using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevels : MonoBehaviour
{
    public int MiningLevel = 1;
    public int MiningStartingExp = 200;
    public int playerMiningExp = 0;
    public int neededExp;
    // Start is called before the first frame update
    void Start()
    {
        neededExp = Mathf.RoundToInt(((MiningLevel) * (2.0f+(MiningLevel)) * MiningStartingExp));
        Debug.Log((2.0f+(MiningLevel/5.0f)).ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void checkMiningExp(int newExp)
    {
        neededExp = Mathf.RoundToInt(((MiningLevel) * (2.0f + (MiningLevel)) * MiningStartingExp));
        playerMiningExp += newExp;
        if(playerMiningExp >= neededExp)
        {
            playerMiningExp -= neededExp;
            MiningLevel++;
            Debug.Log("You Have Leveled Up to: " + MiningLevel);
        }
    }
}
