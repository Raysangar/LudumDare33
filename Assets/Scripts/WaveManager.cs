using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {
    [SerializeField]
    private Transform[] enemiesSpawners;

    [SerializeField]
    private Wave[] wavesInfo;

    private int currentLevel;
    private BloodCollector bloodCollector;

	void Start () {
        bloodCollector = GameObject.Find("BloodCollector").GetComponent<BloodCollector>();
        currentLevel = getMaximunLevelAvailableFor(bloodCollector.accumulatedBlood);
	}
	
	void FixedUpdate () {
        currentLevel = getMaximunLevelAvailableFor(bloodCollector.accumulatedBlood);
        instantiateEnemyIfNecessary();
	}

    private int getMaximunLevelAvailableFor(float bloodAmount)
    {
        int waveIndex = -1;
        for (int i = 0; i < wavesInfo.Length; ++i)
            if (wavesInfo[i].minimunLevelOfBloodNeeded <= bloodAmount && wavesInfo[i].minimunLevelOfBloodNeeded > wavesInfo[waveIndex].minimunLevelOfBloodNeeded)
                waveIndex = i;
        return waveIndex;
    }

    private void instantiateEnemyIfNecessary()
    {
        Dictionary<string, GameObject[]> enemies = getEnemiesOnLevel();
        int enemiesCount = getCurrentNumberOfEnemies(enemies);
        if (enemiesCount < wavesInfo[currentLevel].maximunNumberOfEnemies)
            instantiateNewEnemy(enemiesCount, enemies);
    }

    private Dictionary<string, GameObject[]> getEnemiesOnLevel()
    {
        Dictionary<string, GameObject[]> enemies = new Dictionary<string, GameObject[]>();
        foreach (GameObject enemy in wavesInfo[currentLevel].enemiesOnWave)
            enemies.Add(enemy.tag, GameObject.FindGameObjectsWithTag(enemy.tag));
        return enemies;
    }

    public int getCurrentNumberOfEnemies(Dictionary<string, GameObject[]> enemies)
    {
        int enemiesCount = 0;
        foreach (GameObject[] enemiesOfType in enemies.Values)
            enemiesCount += enemiesOfType.Length;
        return enemiesCount;
    }

    private void instantiateNewEnemy(int enemiesCount, Dictionary<string, GameObject[]> enemies)
    {
        Vector3 spawnPosition = enemiesSpawners[Random.Range(0, enemiesSpawners.Length)].position;
        GameObject enemyToSpawn = getEnemyForInstantiate(enemiesCount, enemies);
        GameObject.Instantiate(enemyToSpawn, spawnPosition, enemyToSpawn.transform.rotation);
    }

    private GameObject getEnemyForInstantiate(int enemiesCount, Dictionary<string, GameObject[]> enemies)
    {
        ArrayList candidateEnemyForInstantiate = new ArrayList();
        for (int i = 0; i < wavesInfo[currentLevel].enemiesOnWave.Length; ++i)
            if (wavesInfo[currentLevel].enemiesAppearanceProbability[i] < (enemiesCount / enemies[wavesInfo[currentLevel].enemiesOnWave[i].tag].Length))
                candidateEnemyForInstantiate.Add(wavesInfo[currentLevel].enemiesOnWave[i]);
        return candidateEnemyForInstantiate[Random.Range(0, candidateEnemyForInstantiate.Count - 1)] as GameObject;
    }
}
