using System;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PhysicsCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<PhysicsCollider>();
    }

    private void LateUpdate()
    {
        var collisions = CollisionDetection.GetCollisions(_collider);
        if (collisions.Length > 0)
        {
            foreach (var collider in collisions)
            {
                if (collider != null)
                {
                    if (collider.CompareTag("DestroyBullet"))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}