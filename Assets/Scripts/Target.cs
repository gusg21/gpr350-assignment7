using System;
using DefaultNamespace;
using UnityEngine;

    public class Target : MonoBehaviour
    {
        public BoxSpawner Spawner;
        
        private PhysicsCollider _collider;
        [SerializeField] private ParticleSystem _particles;
        private MeshRenderer _renderer;

        private float _maxLife = 10f;
        private float _life = 10f;

        private void Awake()
        {
            _collider = GetComponent<PhysicsCollider>();
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            _life -= Time.deltaTime;
            var colorRatio = _life / _maxLife;
            _renderer.material.color = new Color(1f, colorRatio, colorRatio, colorRatio / 2f + 0.5f);

            if (_life < _maxLife * 0.3f)
            {
                _renderer.enabled = (_life % 0.1f) > 0.05f; // blink
            }
            
            if (_life <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void LateUpdate()
        {
            var collisions = CollisionDetection.GetCollisions(_collider);
            if (collisions.Length > 0)
            {
                foreach (var collider in collisions)
                {
                    if (collider.CompareTag("Bullet"))
                    {
                        var parts = Instantiate(_particles, transform.parent);
                        parts.transform.position = transform.position;
                        parts.Play();

                        UIController.I.Emphasize();
                        GameManager.BlocksDestroyed += 1;

                        Spawner.SpawnBlock();
                        
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
