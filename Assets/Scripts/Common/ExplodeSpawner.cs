using UnityEngine;

namespace DefaultNamespace
{
    public class ExplodeSpawner : Singleton<ExplodeSpawner>
    {
        [SerializeField] private ObjectPooler _pooler;

        public void Spawn(Vector2 position, float radius)
        {
            
        }
    }
}