using System;
using DefaultNamespace.Projectiles.Components;
using Projectiles;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody _body;
        public ProjectileDataSO _data;
        
        //public TowerProjectile _tower { get; set; }
        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
        }

        public void SetData(ProjectileDataSO _data)
        {
            this._data = _data;
        }

        public void ResetProjectile()
        {
            GetComponent<ProjectileGenerator>().ResetProjectile();
        }

        public void SetTarget(Enemy.Enemy enemy)
        {
            var movement = GetComponent<ProjectileMovement>();
            if (movement != null)
            {
                movement.SetEnemy(enemy);
            }
        }
    }
}