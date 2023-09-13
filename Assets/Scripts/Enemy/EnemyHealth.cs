using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
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

        private void Update()
        {
            //_healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, currentHealth / maxHealth, Time.deltaTime * 10f);
        }

        public void DealDamage(float damageReceive)
        {
            currentHealth -= damageReceive;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            else OnEnemyHit?.Invoke(_enemy);
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
    }
}