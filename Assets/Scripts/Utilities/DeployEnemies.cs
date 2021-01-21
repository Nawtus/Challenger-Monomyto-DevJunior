using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemies : ScreenBounds
{
    public Object[] enemiesPrefabs;
    private int enemiesValue = 10;
    public int EnemiesValue => enemiesValue;
    private float Crono;
    private float respawnTime = 10f;
    public float RespawnTime => respawnTime;

    void Start()
    {
        GetBackRenderer();
        GetBounds();

        for (int i = 0; i < enemiesValue; i++)
            SpawnEnemies();
    }



    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Crono += Time.deltaTime;

            if (Crono >= respawnTime)
            {
                SpawnEnemies();
                Crono = 0;
            }
        }
    }



    public void SpawnEnemies()
    {
        Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)],
            new Vector2(Random.Range(-Bounds.x, Bounds.x),
            Random.Range(-Bounds.y, Bounds.y)),
            new Quaternion(0, 0, 0, 0));
    }
}
