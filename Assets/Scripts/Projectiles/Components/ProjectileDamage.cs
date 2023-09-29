using System;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components
{
    public class ProjectileDamage : ProjectileComponent<DamageData>
    {
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy.EnemyHealth>().Deal(_componentData.damage);
            }
        }
        
    }
}