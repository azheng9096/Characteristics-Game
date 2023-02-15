using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] Transform[] spawnpointsPool;
    [SerializeField] int minEnemiesCount, maxEnemiesCount;

    [SerializeField] public List<GameObject> enemyPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        int numEnemies = Random.Range(minEnemiesCount, maxEnemiesCount);
        GenerateEnemies(numEnemies);

        // let GameOverUI know how many enemies there are so they can listen for end of level
        GameOverUI.instance.InitGame(numEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEnemies(int num) {
        print("hello");
        List<Transform> spawnpoints = new List<Transform>(spawnpointsPool);

        for (int i = 0; i < num; i++) {
            if (spawnpoints.Count > 0) {
                int r = Random.Range(0, enemyPrefabs.Count);
                int randSpawnpoint = Random.Range(0, spawnpoints.Count);

                GameObject enemy = Instantiate(enemyPrefabs[r], spawnpoints[randSpawnpoint].position, transform.rotation);

                spawnpoints.RemoveAt(randSpawnpoint);
            }
        }
    }
}
