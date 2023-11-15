using System;
using UnityEngine;
using Random = UnityEngine.Random;

    public class RandomRotater : MonoBehaviour
    {
        private void Start()
        {
            transform.rotation = Quaternion.Euler(
                Random.Range(0, 360f),
                Random.Range(0, 360f),
                Random.Range(0, 360f)
            );
        }
    }