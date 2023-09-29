using System;
using DefaultNamespace.Projectiles;
using DefaultNamespace.Projectiles.Components;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerProjectile : MonoBehaviour
    {
        [SerializeField] protected Transform projectileSpawnPosition;
        private float delayBtwAttacks;
        
        public float _counter;
        
        public float DelayPerShot { get; set; }
        protected ObjectPooler _pooler;
        protected float _nextAttackTime;
        public TowerBehaviour _tower;
        protected Projectile _currentProjectile;

        private void Start()
        {
            _pooler = GetComponent<ObjectPooler>();
            _tower = GetComponent<TowerBehaviour>();
            delayBtwAttacks = _tower._towerInfor._timeBtwAttack;
            DelayPerShot = delayBtwAttacks;
            //LoadProjectile();
        }

        private void Update()
        {
            if (IsTurretEmpty())
            {
                LoadProjectile();
            }

            _counter -= Time.deltaTime;
            if (_counter < 0)
            {
                FireProjectile();
            }

        }

        protected virtual void LoadProjectile()
        {
            GameObject newInstance = _pooler.GetInstanceFromPool();
            newInstance.transform.localPosition = projectileSpawnPosition.position;
            //newInstance.transform.SetParent(projectileSpawnPosition);
            
            _currentProjectile = newInstance.GetComponent<Projectile>();
            _currentProjectile.ResetProjectile();
            newInstance.SetActive(true);
        }

        private void FireProjectile()
        {
            if (_tower.CurrentEnemyTarget != null && _currentProjectile != null)
            {
                Debug.Log("Fire " + _tower.CurrentEnemyTarget);
                _currentProjectile.SetTarget(_tower.CurrentEnemyTarget);
                //_currentProjectile.transform.SetParent(null);
                _currentProjectile = null;
                _counter = delayBtwAttacks;
            }
            // _currentProjectile.transform.position = projectileSpawnPosition.position;
        }

        private bool IsTurretEmpty()
        {
            return _currentProjectile == null;
        }
    }
}