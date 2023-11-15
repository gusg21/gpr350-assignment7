using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    {
        public static int BlocksDestroyed = 0;
        public static float MaxTimeLeft = 60.0f;
        public static float TimeLeft = 60.0f;

        public static GameManager I;
        
        private bool _playing = true;
        public static string PLAY_NAME = "TestScene";
        public static string GAME_OVER_NAME = "GameOverScene";

        private void Awake()
        {
            I = this;
            
            DontDestroyOnLoad(gameObject);
            
            SceneManager.activeSceneChanged += SceneManagerOnactiveSceneChanged;
        }

        private void SceneManagerOnactiveSceneChanged(Scene current, Scene next)
        {
            if (next.name == PLAY_NAME)
            {
                TimeLeft = MaxTimeLeft;
                BlocksDestroyed = 0;
                _playing = true;
            }
        }

        private void Update()
        {
            if (_playing)
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0f)
                {
                    SceneManager.LoadSceneAsync(1);
                    _playing = false;
                }
            }
        }
    }