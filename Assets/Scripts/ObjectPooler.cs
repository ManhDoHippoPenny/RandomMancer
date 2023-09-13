using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int poolSize = 0;
        private List<GameObject> _pool;
        private GameObject _holder;

        private void Awake()
        {
            _pool = new List<GameObject>();
            _holder = new GameObject($"Pool - {prefab.name}");
            for (int i = 0; i < poolSize; i++)
            {
                _pool.Add(CreateInstance());
            }
        }

        private GameObject CreateInstance()
        {
            GameObject newInstance = Instantiate(prefab);
            newInstance.transform.SetParent(_holder.transform);
            newInstance.SetActive(false);
            return newInstance;
        }

        public GameObject GetInstanceFromPool()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    return _pool[i];
                }
            }

            return CreateInstance();
        }

        public static void ReturnToPool(GameObject instance)
        {
            instance.SetActive(false);
        }

        public static IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay)
        {
            yield return new WaitForSeconds(delay);
            instance.SetActive(false);
        }
    }
}