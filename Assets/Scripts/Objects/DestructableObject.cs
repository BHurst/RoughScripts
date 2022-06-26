using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public float health = 100;
    public ParticleSystem pSystem;
    public Rigidbody skeleton;
    public Vector3 breakDirection;

    public bool isAlive { get; set; }

    private void Start()
    {
        skeleton = GetComponent<Rigidbody>();
        //pSystem = GetComponent<ParticleSystem>();
    }

    public void PushFromOrigin(Vector3 forceOrigin, float force)
    {
        skeleton.AddForceAtPosition(force * Vector3.Normalize(transform.position - forceOrigin), forceOrigin, ForceMode.Impulse);
        breakDirection = Quaternion.Euler(transform.position - forceOrigin + Quaternion.Euler(90, 0, 0).eulerAngles).eulerAngles;
    }

    public void PushFromDirection(Vector3 forceDirection, float force)
    {
        skeleton.AddForceAtPosition(force * Vector3.Normalize(forceDirection), forceDirection, ForceMode.Impulse);
        breakDirection = Quaternion.LookRotation(forceDirection).eulerAngles + Quaternion.Euler(90, 0, 0).eulerAngles;
    }

    public void InflictDamage(float value, bool overTime)
    {
        health -= value;
        if (health <= 0)
            Break();
    }

    public void Break()
    {
        pSystem.transform.eulerAngles = breakDirection;
        if (pSystem.emission.burstCount > 0)
            pSystem.Emit((int)pSystem.emission.GetBurst(0).count.constant);
        pSystem.transform.SetParent(null);
        pSystem.transform.localScale = new Vector3(1, 1, 1);
        

        Destroy(gameObject);
    }

    private void Update()
    {
        //breakDirection = transform.rotation.eulerAngles;
    }
}