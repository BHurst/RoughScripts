using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, ICanBeDamaged
{
    public float health = 100;
    public ParticleSystem pSystem;

    public bool isAlive { get; set; }

    private void Start()
    {
        //pSystem = GetComponent<ParticleSystem>();
    }

    public void InflictDamage(float value, bool overTime)
    {
        health -= value;
        if (health <= 0)
            Break();
    }

    public void InflictHealing(float value, bool overTime)
    {
        throw new System.NotImplementedException();
    }

    public void Break()
    {
        pSystem.transform.SetParent(null);
        pSystem.transform.localScale = new Vector3(1, 1, 1);
        pSystem.Play();
    }
}