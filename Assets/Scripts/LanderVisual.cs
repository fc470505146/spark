using System;
using UnityEngine;

public class LanderVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThrusterParticlesSystem;
    [SerializeField] private ParticleSystem middleThrusterParticlesSystem;
    [SerializeField] private ParticleSystem rightThrusterParticlesSystem;

    private Lander lander;

    private void Awake()
    {
        lander = GetComponent<Lander>();
        lander.OnUpForce += Lander_OnUpForce;
        lander.OnLeftForce += Lander_OnLeftForce;
        lander.OnRightForce += Lander_OnRightForce;
        lander.OnBeforeForce += Lander_OnBeforeForce;


        SetEnabledThrusterParticleSystem(leftThrusterParticlesSystem, false);
        SetEnabledThrusterParticleSystem(middleThrusterParticlesSystem, false);
        SetEnabledThrusterParticleSystem(rightThrusterParticlesSystem, false);
    }

    private void Lander_OnBeforeForce(object sender, EventArgs e)
    {
        SetEnabledThrusterParticleSystem(leftThrusterParticlesSystem, false);
        SetEnabledThrusterParticleSystem(middleThrusterParticlesSystem, false);
        SetEnabledThrusterParticleSystem(rightThrusterParticlesSystem, false);
    }

    private void Lander_OnRightForce(object sender, EventArgs e)
    {
        SetEnabledThrusterParticleSystem(rightThrusterParticlesSystem, true);
    }

    private void Lander_OnLeftForce(object sender, EventArgs e)
    {
        SetEnabledThrusterParticleSystem(leftThrusterParticlesSystem, true);
    }

    private void Lander_OnUpForce(object sender, System.EventArgs e)
    {
        SetEnabledThrusterParticleSystem(leftThrusterParticlesSystem, true);
        SetEnabledThrusterParticleSystem(middleThrusterParticlesSystem, true);
        SetEnabledThrusterParticleSystem(rightThrusterParticlesSystem, true);
    }

    private void SetEnabledThrusterParticleSystem(ParticleSystem particleSystem, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = enabled;
    }
}
