using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BoxSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _boxPrefabs;
        [SerializeField] private Transform _playAreaMin;
        [SerializeField] private Transform _playAreaMax;

        private float _spawnTimer = 2f;

        private void OnDrawGizmos()
        {
            var minPos = _playAreaMin.position;
            var maxPos = _playAreaMax.position;
            Gizmos.DrawWireCube(Vector3.Lerp(minPos, maxPos, 0.5f), maxPos - minPos);
        }

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0f)
            {
                SpawnBlock();
                var progress = GameManager.TimeLeft / GameManager.MaxTimeLeft;
                var baseTime = Mathf.Lerp(4, 0.5f, progress);
                _spawnTimer = Random.Range(baseTime / 5f, baseTime);
            }
        }

        public void SpawnBlock()
        {
            // Generate a position
            var minPos = _playAreaMin.position;
            var maxPos = _playAreaMax.position;
            var randomPos = new Vector3(
                Random.Range(minPos.x, maxPos.x),
                Random.Range(minPos.y, maxPos.y),
                Random.Range(minPos.z, maxPos.z)
            );

            // Generate a scale
            float volume = float.PositiveInfinity;
            float maxVolume = 170f;
            Vector3 randomScale = new();
            while (volume > maxVolume)
            {
                randomScale = new Vector3(
                    Random.Range(3f, 50f),
                    Random.Range(3f, 50f),
                    Random.Range(3f, 50f)
                );
                volume = randomScale.x * randomScale.y * randomScale.z;
                maxVolume += 0.5f; // To ensure eventually we get out of this loop
            }
            
            // Create a box
            var prefab = _boxPrefabs[Random.Range(0, _boxPrefabs.Length)];
            var box = Instantiate(prefab, transform);
            box.transform.position = randomPos;
            box.transform.localScale = randomScale;
            box.GetComponent<Target>().Spawner = this;
        }
    }
}