using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        Sphere[] spheres = FindObjectsOfType<Sphere>();
        PlaneCollider[] colliders = FindObjectsOfType<PlaneCollider>();

        for(int i = 0; i < spheres.Length; i++)
        {
            Sphere sphereA = spheres[i];
            for(int j = i+1; j < spheres.Length; j++)
            {
                Sphere sphereB = spheres[j];
                CollisionDetection.ApplyCollisionResolution(sphereA, sphereB);
            }

            foreach(PlaneCollider planeCollider in colliders)
            {
                CollisionDetection.ApplyCollisionResolution(sphereA, planeCollider);
            }

            // TODO : you should probably have code here
        }
    }
}
