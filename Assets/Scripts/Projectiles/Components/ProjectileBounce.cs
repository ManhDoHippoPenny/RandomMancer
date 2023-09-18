using System;
using System.Collections.Generic;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components
{
    public class ProjectileBounce : ProjectileComponent<BounceData>
    {
        public int _numEnemies;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _numEnemies > 0)
            {
                _numEnemies--;
                RaycastHit info;
                Physics.SphereCast(transform.position, _componentData._maxDistanceToBounce,transform.forward,out info);
                GetComponent<ProjectileMovement>().SetEnemy(info.collider.GetComponent<Enemy.Enemy>());
            }
        }

        public override void Init()
        {
            base.Init();
            _numEnemies = _componentData._numberOfUnit;
        }
    }
}