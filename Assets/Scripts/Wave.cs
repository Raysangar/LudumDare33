using System;
using UnityEngine;
using System.Collections;

[Serializable]
class Wave
{
    public GameObject[] enemiesOnWave;
    public int[] enemiesAppearanceProbability;
    public int maximunNumberOfEnemies;
    public float appearenceTimePeriod;
}
