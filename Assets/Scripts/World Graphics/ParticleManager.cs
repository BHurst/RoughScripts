using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public Transform parent;
    public ParticleSystem pS;
    public ParticleSystem.EmissionModule em;


    void Start()
    {
        parent = transform.parent;
        pS = GetComponent<ParticleSystem>();
        em = pS.emission;
    }
    
    void Update()
    {
        if(parent == null)
        {
            em.enabled = false;

            if (pS.particleCount == 0)
                Destroy(this.gameObject);
        }
    }
}