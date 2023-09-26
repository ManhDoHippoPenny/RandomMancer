using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class DiceBehaviour : MonoBehaviour
    {
        private PhysicBaseMovement _movement;
        private DragAndDropAble _dragAndDropAble;
        private DiceRoll _diceRoll;

        private void Awake()
        {
            _movement = GetComponent<PhysicBaseMovement>();
            _dragAndDropAble = GetComponent<DragAndDropAble>();
            _diceRoll = GetComponent<DiceRoll>();
            _dragAndDropAble.onRelaseEvent += ApplyForceToDice;
            _movement._velocityOnZero += ChangeStateToSpawner;
        }

        public void ChangeStateToSpawner()
        {
            _dragAndDropAble.onRelaseEvent -= ApplyForceToDice;
        }

        private void ApplyForceToDice()
        {
            _movement.ApplyForce(_dragAndDropAble.Direction, _dragAndDropAble.Speed);
            _diceRoll.RollDice(_dragAndDropAble.Speed, 1,0);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Deal dame");
                //other.transform.GetComponent<EnemyHealth>().DealDamage(1);
            }
        }
    }
}