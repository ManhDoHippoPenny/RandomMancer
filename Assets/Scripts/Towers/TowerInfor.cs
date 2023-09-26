using System;
using System.Collections.Generic;
using DefaultNamespace.Projectiles;
using Projectiles;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [Serializable]
    [CreateAssetMenu(fileName = "TowerInformation", menuName = "Tower Information",order = 0)]
    public class TowerInfor : ScriptableObject
    {
        public string _name;
        public int _cost;
        public int _timeBtwAttack;
        [TextArea] [SerializeField] private string _description;
        //[SerializeField] private ProjectileDataSO _dataProjectile;
        [SerializeField] private List<Vector3> _directionsToShoot;

        public string Name => _name;
        public int Cost => _cost;

        public ProjectileDataSO _DataSo;
    }
}