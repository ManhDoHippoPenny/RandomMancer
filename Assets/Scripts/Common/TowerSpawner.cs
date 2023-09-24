using UnityEngine;

namespace DefaultNamespace
{
    public class TowerSpawner : Singleton<TowerSpawner>
    {
        [SerializeField] private ObjectPooler _pooler;
        
        public GameObject Spawn(Vector3 position)
        {
            GameObject newInstance = _pooler.GetInstanceFromPool();
            newInstance.transform.localPosition = position;
            return newInstance;
        }

    }
}