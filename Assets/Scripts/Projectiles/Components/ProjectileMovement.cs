using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Projectiles.Components
{
    public class ProjectileMovement : ProjectileComponent<MovementData>
    {
        protected Enemy.Enemy _enemyTarget;
        // public UnityAction onEnemyHit;
        private bool _fired = false;
        
        protected void MoveProjectile()
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _enemyTarget.transform.position, _componentData._Speed * Time.deltaTime);
            float distanceToTarget = (_enemyTarget.transform.position - transform.position).magnitude;
            if (distanceToTarget < _componentData._MinDistanceToDamage)
            {
                //onEnemyHit?.Invoke();
                ObjectPooler.ReturnToPool(gameObject);
            }
        }

        protected void RotateProjectile()
        {
            Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
            transform.Rotate(0f,0f,angle);
        }

        public void SetEnemy(Enemy.Enemy _enemy)
        {
            _enemyTarget = _enemy;
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
        
    }
}