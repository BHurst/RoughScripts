using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public Transform parent;
    public ParticleSystem pS;
    public ParticleSystem.EmissionModule em;
    public ParticleSystem.MainModule mm;
    float timer = 0;


    void Start()
    {
        parent = transform.parent;
        pS = GetComponent<ParticleSystem>();
        em = pS.emission;
        mm = pS.main;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(parent == null && timer > .03f)
        {
            em.enabled = false;
            //mm.loop = false;

            if (pS.particleCount == 0 && timer > .3f)
                Destroy(this.gameObject);
        }
    }
}