using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParticleParent : MonoBehaviour
{
    public ParticleSystem BurnParticles;
    public ParticleSystem OverchargeParticles;
    public ParticleSystem SoulRotParticles;
    public ParticleSystem DecayParticles;
    public ParticleSystem BleedParticles;

    void Start()
    {
        BurnParticles = transform.Find("State_Burn_Particles").GetComponent<ParticleSystem>();
        OverchargeParticles = transform.Find("State_Overcharge_Particles").GetComponent<ParticleSystem>();
        SoulRotParticles = transform.Find("State_SoulRot_Particles").GetComponent<ParticleSystem>();
        DecayParticles = transform.Find("State_Decay_Particles").GetComponent<ParticleSystem>();
        BleedParticles = transform.Find("State_Bleed_Particles").GetComponent<ParticleSystem>();
    }
}