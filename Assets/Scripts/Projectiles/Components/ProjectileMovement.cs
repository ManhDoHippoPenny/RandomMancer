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
            if(!_enemyTarget.gameObject.activeInHierarchy) ObjectPooler.ReturnToPool(gameObject);
            transform.position = Vector3.MoveTowards(transform.position,
                _enemyTarget.transform.position, _componentData._Speed * Time.deltaTime);
        }

        protected void RotateProjectile()
        {
            Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
            //Debug.Log(angle);
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