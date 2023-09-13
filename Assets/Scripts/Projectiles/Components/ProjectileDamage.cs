using System;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components
{
    public class ProjectileDamage : ProjectileComponent<DamageData>
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy.EnemyHealth>().DealDamage(_componentData.damage);
            }
        }
    }
}