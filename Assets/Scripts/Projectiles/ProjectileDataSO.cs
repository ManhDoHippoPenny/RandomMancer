using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEngine;

namespace Projectiles
{
    [Serializable]
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "", order = 0)]
    public class ProjectileDataSO : ScriptableObject
    {
        [field: SerializeReference]
        public List<ComponentData> _componentData { get; private set; }

        public T GetData<T>()
        {
            return _componentData.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependencies()
        {
            return _componentData.Select(_component => _component._componentDependency).ToList();
        }

        public void AddData(ComponentData data)
        {
            if (_componentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            {
                return;
            }
            
            _componentData.Add(data);
        }
    }
}
