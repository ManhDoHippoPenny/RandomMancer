using UnityEngine;

namespace DefaultNamespace.Projectiles.Components.ComponentData
{
    public class MovementData: ComponentData
    {
        [field: SerializeField] public float _MinDistanceToDamage;
        [field: SerializeField] public float _Speed;
        
        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(ProjectileMovement);
        }
    }
}