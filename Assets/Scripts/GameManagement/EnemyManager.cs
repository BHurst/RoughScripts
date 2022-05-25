using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<RootCharacter> allNpcs = new List<RootCharacter>();
    public Vector3 spawnPoint;
    public float patrolAreaRadius;
    public float timer = 0;
    public float spawnRate;
    public float spawnMax;
    public NPCUnit spawnCopy;
    public int navSet = 6;
    public Transform navCollection;
    public Transform npcList;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            timer = 0;

            if(allNpcs.Count < spawnMax)
            {
                navSet++;

                GameObject newEnemy = Instantiate(Resources.Load(String.Format("Prefabs/Characters/NPCEnemy")), spawnPoint, new Quaternion()) as GameObject;

                newEnemy.transform.SetParent(npcList);
                allNpcs.Add(newEnemy.GetComponent<NPCUnit>());

                GameObject set = new GameObject() { name = String.Format("nav{0}", navSet) };

                newEnemy.GetComponent<RootCharacter>().name = UnityEngine.Random.Range(0, 500000).ToString();

                set.transform.SetParent(navCollection);
                set.transform.position = spawnPoint;

                GameObject path1 = new GameObject() { name = "pat1" };
                GameObject path2 = new GameObject() { name = "pat2" };
                GameObject path3 = new GameObject() { name = "pat3" };
                GameObject path4 = new GameObject() { name = "pat4" };

                path1.transform.SetParent(set.transform);
                path2.transform.SetParent(set.transform);
                path3.transform.SetParent(set.transform);
                path4.transform.SetParent(set.transform);

                path1.transform.position = new Vector3(UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.x, patrolAreaRadius + set.transform.position.x), 0, UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.z, patrolAreaRadius + set.transform.position.z));
                path2.transform.position = new Vector3(UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.x, patrolAreaRadius + set.transform.position.x), 0, UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.z, patrolAreaRadius + set.transform.position.z));
                path3.transform.position = new Vector3(UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.x, patrolAreaRadius + set.transform.position.x), 0, UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.z, patrolAreaRadius + set.transform.position.z));
                path4.transform.position = new Vector3(UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.x, patrolAreaRadius + set.transform.position.x), 0, UnityEngine.Random.Range(-patrolAreaRadius + set.transform.position.z, patrolAreaRadius + set.transform.position.z));

                newEnemy.GetComponent<Patrol>().points.Add(path1.transform);
                newEnemy.GetComponent<Patrol>().points.Add(path2.transform);
                newEnemy.GetComponent<Patrol>().points.Add(path3.transform);
                newEnemy.GetComponent<Patrol>().points.Add(path4.transform);
            }
        }
    }
}