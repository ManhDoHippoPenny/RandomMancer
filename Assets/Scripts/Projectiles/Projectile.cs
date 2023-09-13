using System;
using DefaultNamespace.Towers;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public static UnityAction<Enemy.Enemy, float> onEnemyHit;

        [SerializeField] protected float moveSpeed;
        [SerializeField] private float minDistanceToDealDame;

        private Rigidbody _body;
        public float Damage { get; set; }
        
        public TowerProjectile _tower { get; set; }

        protected Enemy.Enemy _enemyTarget;
        private bool _fired;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_enemyTarget != null)
            {
                MoveProjectile();
                RotateProjectile();
                _fired = true;
            }
            else
            {
                if (_fired)
                {
                    ObjectPooler.ReturnToPool(gameObject);
                }
            }
        }

        public void SetData(ProjectileDataSO _data)
        {
            
        }
        
        protected void MoveProjectile()
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _enemyTarget.transform.position, moveSpeed * Time.deltaTime);
            float distanceToTarget = (_enemyTarget.transform.position - transform.position).magnitude;
            if (distanceToTarget < minDistanceToDealDame)
            {
                onEnemyHit?.Invoke(_enemyTarget, Damage);
                
                ObjectPooler.ReturnToPool(gameObject);
            }
        }

        private void RotateProjectile()
        {
            Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
            transform.Rotate(0f,0f,angle);
        }

        public void SetEnemy(Enemy.Enemy enemy)
        {
            _enemyTarget = enemy;
        }

        public void ResetProjectile()
        {
            
        }
    }
}