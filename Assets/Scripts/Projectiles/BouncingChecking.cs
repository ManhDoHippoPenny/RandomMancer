using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Projectiles
{
    public class BouncingChecking : MonoBehaviour
    {
        public List<Enemy.Enemy> _enemies;
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