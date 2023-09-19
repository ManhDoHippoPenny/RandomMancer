using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerRanger : MonoBehaviour
    {
        [SerializeField] private TowerBehaviour _towerBehaviour;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _towerBehaviour._enemies.Add(other.GetComponent<Enemy.Enemy>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy.Enemy enemy = other.GetComponent<Enemy.Enemy>();
            if (other.CompareTag("Enemy") && _towerBehaviour._enemies.Contains(enemy))
            {
                _towerBehaviour._enemies.Remove(enemy);
            }
        }
    }
}