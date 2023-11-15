using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator
{
    public static void Integrate(Particle3D particle, float dt)
    {
        particle.acceleration = particle.accumulatedForces * particle.inverseMass + particle.gravity;

        particle.transform.position += particle.velocity * dt + particle.gravity * dt * dt * 0.5f;

        particle.velocity += particle.acceleration * dt;
        particle.velocity *= Mathf.Pow(particle.damping, dt);
    }
}
