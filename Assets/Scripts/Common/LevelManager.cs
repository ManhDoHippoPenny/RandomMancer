using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private int lives = 10;
        [SerializeField] public int _width, _height;
        [SerializeField] public float _size;
        [SerializeField] public Transform _root;
        [SerializeField] private Transform _prefab;
        
        public int TotalLives { get; set; }
        public int CurrentWave { get; set; }

        private void Start()
        {
            TotalLives = lives;
            CurrentWave = 1;
            _size = _prefab.GetComponent<MeshRenderer>().bounds.size.x;
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