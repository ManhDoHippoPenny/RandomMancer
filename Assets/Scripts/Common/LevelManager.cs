using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private int lives = 10;
        [SerializeField] public int _width, _height;
        
        public int TotalLives { get; set; }
        public int CurrentWave { get; set; }

        private void Start()
        {
            TotalLives = lives;
            CurrentWave = 1;
        }

        private void ReduceLives()
        {
            TotalLives--;
            if (TotalLives <= 0)
            {
                TotalLives = 0;
                GameOver();
            }
            
            
        }

        private void GameOver()
        {
            
        }

        private void WaveComplete()
        {
            
        }
    }
}