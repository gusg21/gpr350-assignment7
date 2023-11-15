using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        CollisionDetection.ClearCollisionRegistry();
        
        Sphere[] spheres = FindObjectsOfType<Sphere>();
        PlaneCollider[] planes = FindObjectsOfType<PlaneCollider>();
        OBBCollider[] obbs = FindObjectsOfType<OBBCollider>();
        AABBCollider[] aabbs = FindObjectsOfType<AABBCollider>();

        for (int i = 0; i < spheres.Length; i++)
        {
            Sphere sphereA = spheres[i];
            for (int j = i + 1; j < spheres.Length; j++)
            {
                Sphere sphereB = spheres[j];
                CollisionDetection.ApplyCollisionResolution(sphereA, sphereB);
            }

            foreach (PlaneCollider planeCollider in planes)
            {
                CollisionDetection.ApplyCollisionResolution(sphereA, planeCollider);
            }

            foreach (var obb in obbs)
            {
                CollisionDetection.ApplyCollisionResolution(sphereA, obb);
            }

            foreach (var aabb in aabbs)
            {
                CollisionDetection.ApplyCollisionResolution(sphereA, aabb);
            }

            // TODO : you should probably have code here
        }
    }
}