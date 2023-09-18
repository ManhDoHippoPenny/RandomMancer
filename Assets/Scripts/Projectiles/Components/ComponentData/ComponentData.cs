using System;
using UnityEngine;

namespace DefaultNamespace.Projectiles.Components.ComponentData
{
    [Serializable]
    public abstract class ComponentData
    {
        [SerializeField, HideInInspector] private string name;
     
        public Type _componentDependency { get; protected set; }
     
        public ComponentData()
        {
            SetComponentName();
            SetComponentDependency();
        }

        public void SetComponentName() => name = GetType().Name;

        protected abstract void SetComponentDependency();
     
        public virtual void SetAttackDataNames()
        {
          
        }

        public virtual void InitializeAttackData()
        {
        }
    }
}