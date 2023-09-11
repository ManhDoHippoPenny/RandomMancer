using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float delayBtwSpawns;

        private float _spawnTime;
        private int _enemiesSpawned;

        private void Start()
        {
            
        }

        private void Update()
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime < 0)
            {
                _spawnTime = delayBtwSpawns;
                Spawn();
            }
        }

        public void Spawn()
        {
            // GameObject instance = 
        }
    }
}