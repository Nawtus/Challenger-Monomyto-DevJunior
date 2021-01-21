using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBoxs : ScreenBounds
{
    public Object[] objectsPrefabs;
    private int objectsValue = 20;
    public int Objects => objectsValue;
    private float Crono;
    private float respawnTime = 5f;
    private float RespawnTime => respawnTime;


    void Start()
    {
        GetBackRenderer();
        GetBounds();

        for (int i = 0; i < objectsValue; i++)
            SpawnBox();
    }



    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Crono += Time.deltaTime;

            if (Crono >= respawnTime)
            {
                SpawnBox();
                Crono = 0;
            }
        }
    }



    public void SpawnBox()
    {
        Instantiate(objectsPrefabs[Random.Range(0,objectsPrefabs.Length)],
            new Vector2(Random.Range(-Bounds.x, Bounds.x),
            Random.Range(-Bounds.y, Bounds.y)),
            new Quaternion(0,0,0,0));
    }
}
