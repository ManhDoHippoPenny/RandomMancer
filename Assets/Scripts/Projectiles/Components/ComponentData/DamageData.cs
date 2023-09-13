using System;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components.ComponentData
{
    [Serializable]
    public class DamageData: ComponentData
    {
        [field: SerializeField] public int damage { get; private set;}
        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(ProjectileDamage);
        }
    }
}