using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject Enemy;
    private void Start()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
