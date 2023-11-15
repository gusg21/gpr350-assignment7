using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    private PhysicsCollider _collider;
    private MeshRenderer _renderer;
    
    private void Awake()
    {
        _collider = GetComponent<PhysicsCollider>();
        _renderer = GetComponent<MeshRenderer>();

        _renderer.material.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.9f, 0.8f);
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