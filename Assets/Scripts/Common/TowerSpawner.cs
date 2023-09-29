using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TowerSpawner : Singleton<TowerSpawner>
    {
        private ObjectPooler _pooler;

        private void Start()
        {
            _pooler = GetComponent<ObjectPooler>();
        }

        public GameObject Spawn(Vector3 position)
        {
            GameObject newInstance = _pooler.GetInstanceFromPool();
            newInstance.transform.localPosition = position;
            newInstance.SetActive(true);
            return newInstance;
        }

    }
}