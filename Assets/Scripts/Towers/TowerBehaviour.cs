using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace DefaultNamespace.Towers
{
    public class TowerBehaviour : MonoBehaviour
    {
        public TowerInfor _towerInfor;
        public List<Enemy.Enemy> _enemies;

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
            transform.Rotate(0f,angle,0f);
        }
    }
}