using System;
using DefaultNamespace.Projectiles;
using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerProjectile : MonoBehaviour
    {
        [SerializeField] protected Transform projectileSpawnPosition;
        [SerializeField] private float delayBtwAttacks;
        [SerializeField] private float damage;
        
        public float Damage { get; set; }
        public float _counter;
        
        public float DelayPerShot { get; set; }
        protected ObjectPooler _pooler;
        protected float _nextAttackTime;
        protected TowerBehaviour _tower;
        protected Projectile _currentProjectile;

        private void Start()
        {
            _pooler = GetComponent<ObjectPooler>();
            _tower = GetComponent<TowerBehaviour>();

            Damage = damage;
            DelayPerShot = delayBtwAttacks;
            LoadProjectile();
        }

        private void Update()
        {
            if (IsTurretEmpty())
            {
                LoadProjectile();
            }

            _counter -= Time.deltaTime;
            if (_counter <= 0)
            {
                if (_tower.CurrentEnemyTarget != null && _currentProjectile != null &&
                    _tower.CurrentEnemyTarget._enemyHealth.currentHealth > 0f)
                {
                    _currentProjectile.transform.parent = null;
                    _currentProjectile.SetEnemy(_tower.CurrentEnemyTarget);
                    _currentProjectile = null;
                    _counter = delayBtwAttacks;
                    Debug.Log("Fire");
                }
            }

        }

        protected virtual void LoadProjectile()
        {
            GameObject newInstance = _pooler.GetInstanceFromPool();
            newInstance.transform.localPosition = projectileSpawnPosition.position;
            newInstance.transform.SetParent(projectileSpawnPosition);
            
            _currentProjectile = newInstance.GetComponent<Projectile>();
            _currentProjectile._tower = this;
            _currentProjectile.Damage = Damage;
            _currentProjectile.ResetProjectile();
            newInstance.SetActive(true);
        }

        private void FireProjectile(Vector3 direction)
        {
            _currentProjectile.transform.position = projectileSpawnPosition.position;
        }

        private bool IsTurretEmpty()
        {
            return _currentProjectile == null;
        }
    }
}