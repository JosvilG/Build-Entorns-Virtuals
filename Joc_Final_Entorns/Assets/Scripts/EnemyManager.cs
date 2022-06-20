using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /*public Transform SpawnPoint;
    public GameObject enemic;
    public List<GameObject> enemies;

    void Start()
    {
        enemies = new List<GameObject>();
        
        Instantiate(enemies[0], SpawnPoint.position, SpawnPoint.rotation);
        SpawnPoint.position = new Vector3(0, 2, 50);
        Instantiate(enemies[1], SpawnPoint.position, SpawnPoint.rotation);

        foreach (var enemy in GameObject.FindGameObjectsWithTag("enemic"))
        {
            var enemyScript = enemy.AddComponent<EnemicControler>();
            enemyScript.enemyManager = this;
            enemies.Add(enemy);
        }
    }*/
}
