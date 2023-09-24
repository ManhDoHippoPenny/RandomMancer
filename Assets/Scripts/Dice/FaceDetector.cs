using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class FaceDetector : MonoBehaviour
    {
        private Rigidbody _body;

        private int _diceIndex = -1;
        public int topFace;

        private bool _hasStoppedRolling;
        private bool _delayFinished;
        [SerializeField] private List<Transform> _faces;

        public static UnityAction<int, int> OnDiceResult;

        private PhysicBaseMovement _physic;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _physic = GetComponent<PhysicBaseMovement>();
        }

        private void OnEnable()
        {
            _physic._velocityOnZero += GetNumberOnTopFace;
            
        }
        
        private void OnDisable()
        {
            _physic._velocityOnZero -= GetNumberOnTopFace;
        }

        private void Update()
        {
            if (_delayFinished) return;

            if (_hasStoppedRolling && _body.velocity.sqrMagnitude == 0f)
            {
                _hasStoppedRolling = true;
                
            }
        }

        [ContextMenu("Get number on top face")]
        private void GetNumberOnTopFace()
        {
            if (_faces == null) return ;
            var topFace = 0;
            var lastYPosition = _faces[0].position.z;

            for (int i = 0; i < _faces.Count; i++)
            {
                if (_faces[i].position.z < lastYPosition)
                {
                    lastYPosition = _faces[i].position.z;
                    topFace = i;
                }
            }
            
            Debug.Log($"Dice result {topFace}");
            
            OnDiceResult?.Invoke(_diceIndex,topFace);
            this.topFace = topFace;
            return ;

        }
    }
}