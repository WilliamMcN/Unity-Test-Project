using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNode : MonoBehaviour
{
    public GameObject[] monsters;
    public float[] monsterSpawnTime;
    public float[] defaultMonsterSpawnTime;
    public float negativeDist;
    public float positiveDist;
    // Update is called once per frame
    void Start()
    {
        //tempPosArray = Array.copy(masterArray, tempPosArray, masterArray.Length);
        //defaultMonsterSpawnTime = System.Array.Copy(monsterSpawnTime, defaultMonsterSpawnTime, monsterSpawnTime.Length);
        monsterSpawnTime.CopyTo(defaultMonsterSpawnTime, 0);
        //System.Array.Copy(monsterSpawnTime, defaultMonsterSpawnTime, monsterSpawnTime.Length);
    }
    void Update()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
                if (monsters[i].active == false)
                {
                    monsterSpawnTime[i] -= Time.deltaTime;
                    if(monsterSpawnTime[i] <= 0)
                    {
                        monsters[i].SetActive(true);
                        monsterSpawnTime[i] = defaultMonsterSpawnTime[i];
                    }
                }
        }
    }
}
