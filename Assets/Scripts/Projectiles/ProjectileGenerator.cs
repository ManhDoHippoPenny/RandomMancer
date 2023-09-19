using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Projectiles.Components;
using Projectiles;
using UnityEngine;

namespace DefaultNamespace.Projectiles
{
    public class ProjectileGenerator : MonoBehaviour
    {
        [SerializeField] private Projectile _bullet;
        [SerializeField] private ProjectileDataSO _bulletDataSo;

        private List<ProjectileComponent> componentAlreadyOnBullet = new List<ProjectileComponent>();

        private List<ProjectileComponent> componentAddedToBullet = new List<ProjectileComponent>();

        private List<Type> componentDependencies = new List<Type>();

        private void Start()
        {
            GenerateBullet(_bulletDataSo);
        }

        public void GenerateBullet(ProjectileDataSO data)
        {
            _bullet.SetData(data);
            componentAlreadyOnBullet.Clear();
            componentDependencies.Clear();

            componentAlreadyOnBullet = GetComponents<ProjectileComponent>().ToList();

            componentDependencies = data.GetAllDependencies();
            
            foreach (var dependency in componentDependencies)
            {
                if (componentAddedToBullet.FirstOrDefault(component => component.GetType() == dependency)) continue;

                var bulletComponent =
                    componentAlreadyOnBullet.FirstOrDefault(component => component.GetType() == dependency);

                if (bulletComponent == null)
                {
                    bulletComponent = gameObject.AddComponent(dependency) as ProjectileComponent;
                }
                
                bulletComponent.Init();

                componentAddedToBullet.Add(bulletComponent);

            }

            var componentsToRemove = componentAlreadyOnBullet.Except(componentAddedToBullet);

            foreach (var bulletComponent in componentsToRemove)
            {
                Destroy(bulletComponent);
            }
        }

        public void ResetProjectile()
        {
            
            foreach (var dependency in componentDependencies)
            {
                var bulletComponent = componentAddedToBullet.FirstOrDefault(component => component.GetType() == dependency);
                bulletComponent.Init();
            }
        }
    }
}