using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class DiceBehaviour : MonoBehaviour
    {
        private PhysicBaseMovement _movement;
        private DragAndDropAble _dragAndDropAble;
        private DiceRoll _diceRoll;
        [SerializeField] private List<TowerInfor> _faces;
        
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
            _dragAndDropAble.onRelaseEvent += SpawnTower;
        }

        private void SpawnTower()
        {
            int index = Random.Range(0, 6);
            TowerSpawner.Instance.SpawnTower(this.transform.position,_faces[0]);
        }

        private void ApplyForceToDice()
        {
            _movement.ApplyForce(_dragAndDropAble.Direction, _dragAndDropAble.Speed);
            _diceRoll.RollDice(_dragAndDropAble.Speed, 1,0);
        }
    }
}