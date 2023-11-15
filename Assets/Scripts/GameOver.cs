using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameOver : MonoBehaviour
    {
        public int PlaySceneId = 0;
        public TMP_Text ScoreText;
        
        private void Start()
        {
            ScoreText.text = "Final Score: " + GameManager.BlocksDestroyed;
        }

        private void Update()
        {
            if (Keyboard.current.anyKey.isPressed)
            {
                SceneManager.LoadScene(PlaySceneId);
            }
        }
    }
}