using System;
using DefaultNamespace.Towers;
using UnityEngine;

namespace DefaultNamespace
{
    public class DiceSpawnTower : MonoBehaviour
    {
        public void OnEnable()
        {
            GetComponent<PhysicBaseMovement>()._velocityOnZero += SpawnTowerAtLocation;
        }

        public void OnDisable()
        {
            GetComponent<PhysicBaseMovement>()._velocityOnZero -= SpawnTowerAtLocation;
        }

        public void SpawnTowerAtLocation()
        {
            var tower = TowerSpawner.Instance.SpawnTower(GetComponent<DetectPosition>().result);
        }
    }
}