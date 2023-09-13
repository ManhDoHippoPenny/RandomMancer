using System;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components
{
    public abstract class ProjectileComponent : MonoBehaviour
    {
        protected Projectile _projectile;
        public virtual void Init(){}

        protected void Awake()
        {
            _projectile = GetComponent<Projectile>();
        }
    }

    public abstract class ProjectileComponent<T1> : ProjectileComponent where T1 : ComponentData.ComponentData
    {
        
    }
}