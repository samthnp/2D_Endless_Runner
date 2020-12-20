using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int damageValue = 1;
    public float enemySpeed;

    public float enemyLifeTimeValue;

    private void Update()
    {
        transform.Translate(Vector2.left * (enemySpeed * Time.deltaTime));
        EnemyLifeTime();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().playerHealth = other.GetComponent<Player>().playerHealth - damageValue;
            Debug.Log(other.GetComponent<Player>().playerHealth);
            Destroy(gameObject);
        }
    }
    void EnemyLifeTime()
    {
        enemyLifeTimeValue = enemyLifeTimeValue - Time.deltaTime;

        if (enemyLifeTimeValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
