using UnityEngine;

namespace DefaultNamespace.Projectiles.Components.ComponentData
{
    public class BounceData: ComponentData
    {
        [field: SerializeField] public int _numberOfUnit { get; private set;}
        [field: SerializeField] public float _maxDistanceToBounce { get; private set; }
        
        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(ProjectileBounce);
        }
    }
}