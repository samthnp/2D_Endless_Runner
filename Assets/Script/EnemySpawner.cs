using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPattern;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreasingTime;

    private void Update()
    {
        TimeConstraint();
        
        if (timeBetweenSpawn <= 0)
        {
            int randomPattern = Random.Range(0, enemyPattern.Length);
            Instantiate(enemyPattern[randomPattern], transform.position, quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            startTimeBetweenSpawn = startTimeBetweenSpawn - decreasingTime;
        }
        else
        {
            timeBetweenSpawn = timeBetweenSpawn - Time.deltaTime;
        }
    }
    // to make sure starting time doesn't get too low and spawn enemies in crazy interval
    private void TimeConstraint()
    {
        if (startTimeBetweenSpawn < 0.75)
        {
            startTimeBetweenSpawn = (float) 0.75;
        }
    }
}
