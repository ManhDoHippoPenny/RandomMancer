using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] private TowerInfor _towerInfor;
        [SerializeField] private List<Enemy.Enemy> _enemies;

        public Enemy.Enemy CurrentEnemyTarget;
        
        public void SetTowerInfor(TowerInfor infor)
        {
            _towerInfor = infor;
        }

        private void Update()
        {
            GetCurrentEnemyTarget();
            RotateTowardTargets();
        }

        private void GetCurrentEnemyTarget()
        {
            if (_enemies.Count <= 0)
            {
                CurrentEnemyTarget = null;
                return;
            }

            CurrentEnemyTarget = _enemies[0];
        }

        private void RotateTowardTargets()
        {
            if (CurrentEnemyTarget == null)
            {
                return;
            }

            Vector3 targetPos = CurrentEnemyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, targetPos, transform.forward);
            transform.Rotate(0f,0f,angle);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _enemies.Add(other.GetComponent<Enemy.Enemy>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy.Enemy enemy = other.GetComponent<Enemy.Enemy>();
            if (other.CompareTag("Enemy") && _enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }
        }
    }
}