using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        [SerializeField] private float delayBtwSpawns;
        [SerializeField] private Transform _posSpawn;

        private float _spawnTime;
        private int _enemiesSpawned;

        private ObjectPooler _pooler;

        private void Start()
        {
            _pooler = GetComponent<ObjectPooler>();
        }

        private void Update()
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime < 0)
            {
                _spawnTime = delayBtwSpawns;
                Spawn(_posSpawn.position);
            }
        }

        public void Spawn(Vector3 position)
        {
            GameObject newInstace = _pooler.GetInstanceFromPool();
            newInstace.SetActive(true);
            newInstace.transform.position = position;
        }
    }
}