using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private int lives = 10;
        
        public int TotalLives { get; set; }
        public int CurrentWave { get; set; }

        private void Start()
        {
            TotalLives = lives;
            CurrentWave = 1;
        }

        private void ReduceLives(Enemy.Enemy enemy)
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

        private void OnEnable()
        {
            Enemy.Enemy.OnEndReached += ReduceLives;
        }

        private void OnDisable()
        {
            Enemy.Enemy.OnEndReached -= ReduceLives;
        }
    }
}