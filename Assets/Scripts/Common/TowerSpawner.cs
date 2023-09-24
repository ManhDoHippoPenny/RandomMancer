using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerSpawner : Singleton<TowerSpawner>
    {
        [SerializeField] private GameObject _TowerPrefab;
        [SerializeField] private GameObject _holder;
        private ObjectPooler _pooler;

        private void Start()
        {
            _pooler = GetComponent<ObjectPooler>();
        }

        public GameObject SpawnTower(Vector3 positionSpawn)
        {
            GameObject newInstance = _pooler.GetInstanceFromPool();
            newInstance.transform.localPosition = positionSpawn;
            newInstance.transform.SetParent(_holder.transform);

            return newInstance;
        }
    }
}