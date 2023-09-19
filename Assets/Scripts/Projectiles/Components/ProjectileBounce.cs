using System;
using System.Collections.Generic;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components
{
    public class ProjectileBounce : ProjectileComponent<BounceData>
    {
        public int _numEnemies;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy") && _numEnemies > 0)
            {
                _numEnemies--;
                BouncingChecking _bounceCheck = GetComponentInChildren<BouncingChecking>();
                if (_bounceCheck._enemies.Contains(other.gameObject.GetComponent<Enemy.Enemy>()))
                {
                    _bounceCheck._enemies.Remove(other.gameObject.GetComponent<Enemy.Enemy>());
                }
                if (_numEnemies == 0)
                {
                    ObjectPooler.ReturnToPool(gameObject);
                    return;
                }
                if (_bounceCheck._enemies.Count != 0)
                {
                    GetComponent<ProjectileMovement>().SetEnemy(_bounceCheck._enemies[0]);
                }
            }
        }
        

        public override void Init()
        {
            base.Init();
            _numEnemies = _componentData._numberOfUnit;
            GetComponentInChildren<BouncingChecking>().GetComponent<SphereCollider>().radius =
                _componentData._maxDistanceToBounce;
        }
    }
}