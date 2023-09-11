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

        private bool _hasStoppedRolling;
        private bool _delayFinished;
        [SerializeField] private List<Transform> _faces;

        public static UnityAction<int, int> OnDiceResult;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
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
        private int GetNumberOnTopFace()
        {
            if (_faces == null) return -1;
            var topFace = 0;
            var lastYPosition = _faces[0].position.y;

            for (int i = 0; i < _faces.Count; i++)
            {
                if (_faces[i].position.y > lastYPosition)
                {
                    lastYPosition = _faces[i].position.y;
                    topFace = i;
                }
            }
            
            Debug.Log($"Dice result {topFace}");
            
            OnDiceResult?.Invoke(_diceIndex,topFace);
            return topFace;

        }
    }
}