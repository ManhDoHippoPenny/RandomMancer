using UnityEngine;

namespace DefaultNamespace
{
    public class TowerSpawner : Singleton<TowerSpawner>
    {
        [SerializeField] private GameObject _TowerPrefab;
        [SerializeField] private GameObject _holder;
        
    }
}