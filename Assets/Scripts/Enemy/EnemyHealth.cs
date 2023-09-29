using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamagable
    {
        public static UnityAction<Enemy> OnEnemyKilled;
        public static UnityAction<Enemy> OnEnemyHit;

        [SerializeField] private GameObject healthBarPrefab;
        [SerializeField] private Transform barPos;
        [SerializeField] private float initialHealth ;
        [SerializeField] private float maxHealth;
        
        public float currentHealth { get; set; }
        private Image _healthBar;
        private Enemy _enemy;
        
        private void Start()
        {
            currentHealth = initialHealth;
            _enemy = GetComponent<Enemy>();
        }

        public void Die()
        {
            ResetHealth();
            ObjectPooler.ReturnToPool(gameObject);
        }

        public void ResetHealth()
        {
            currentHealth = initialHealth;
        }

        public void Deal(int dame)
        {
            currentHealth -= dame;
            Debug.Log(currentHealth + "Health");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            else OnEnemyHit?.Invoke(_enemy);
        }
    }
}