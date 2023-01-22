using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class AreaSpawner : MonoBehaviour
{
    public CollectableGameObject collectableGameObject;

    public List<CollectableGameObject> spawnedGameObjects = new List<CollectableGameObject>();
    public int maxSpawnCount = 10;
    public float spawnRadius = 10;
    public float spawnPeriod = 2f;
    public bool isTrainSpawner;

    private float nextSpawnTime = 0;
    void Update()
    {
        HandleNullElements();
        if (spawnedGameObjects.Count >= maxSpawnCount)
        {
            return;
        }

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnPeriod;
            SpawnObject();
        }

    }

    private void SpawnObject()
    {
        var circlePos = Random.insideUnitCircle;
       
        if (isTrainSpawner)
        {
            Vector3 spawnPosition = new Vector3(1,1,0);
            spawnPosition += transform.position;
            var collectable = Instantiate(collectableGameObject, transform);
            collectable.transform.position = spawnPosition;
            spawnedGameObjects.Add(collectable);
        }
        else
        {
            Vector3 spawnPosition = new Vector3(circlePos.x, 0.06f, circlePos.y) * spawnRadius;
            spawnPosition += transform.position;
            var collectable = Instantiate(collectableGameObject, null);
            collectable.transform.position = spawnPosition;
            spawnedGameObjects.Add(collectable);            collectable.transform.DORotate(Vector3.up * 360f, 5f, RotateMode.LocalAxisAdd).SetLoops(-1);
        }
      


    }

    private void HandleNullElements()
    {
        for (int i = spawnedGameObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedGameObjects[i] == null)
            {
                spawnedGameObjects.RemoveAt(i);
            }
        }

    }
}
