using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public Transform folder;
    public int currentCrates = 0;
    public int maxCrates = 50;
    public float spawnRate = .1f;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate && currentCrates < maxCrates)
        {
            GameObject crate = Instantiate(Resources.Load("Prefabs/Objects/DestructableObjects/DestructableCrate"), transform.position + new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f)), new Quaternion(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0), folder) as GameObject;
        }
        currentCrates = folder.childCount;
    }
}